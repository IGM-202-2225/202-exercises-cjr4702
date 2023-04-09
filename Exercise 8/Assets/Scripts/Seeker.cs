using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public Agent fleer;

    protected override void CalculateSteeringForces()
    {
        Vector3 targetPos = fleer.physicsObject.Position;
        targetPos.z = 0f;

        Seek(targetPos);
    }
}
