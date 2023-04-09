using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    public Agent seeker;

    private Vector3 cameraSize;

    protected override void Awake()
    {
        base.Awake();

        Teleport();
    }

    protected override void CalculateSteeringForces()
    {
        Vector3 targetPos = seeker.physicsObject.Position;
        targetPos.z = 0f;

        Flee(targetPos);
    }

    protected override void Update()
    {
        base.Update();

        Collision();
    }

    void Collision()
    {
        float sRad = seeker.physicsObject.Radius;
        float fRad = physicsObject.Radius;
        Vector3 sPos = seeker.physicsObject.Position;
        Vector3 fPos = physicsObject.Position;

        if (sRad + fRad > Mathf.Sqrt(Mathf.Pow(sPos.x - fPos.x, 2) + Mathf.Pow(sPos.y - fPos.y, 2)))
        {
            Teleport();
        }
    }

    void Teleport() 
    {
        cameraSize.y = Camera.main.orthographicSize;
        cameraSize.x = cameraSize.y * Camera.main.aspect;

        transform.position = new Vector3(Random.Range(-cameraSize.x / 2, cameraSize.x / 2), Random.Range(-cameraSize.y / 2, cameraSize.y / 2), 0);
    }
}
