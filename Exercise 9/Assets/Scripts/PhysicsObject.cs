using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 direction;

    public float mass = 1f;

    public bool bounceOffWalls = true;

    public bool useGravity = false;

    public bool useFriction = false;

    public float frictionCoeff = 0.2f;

    private Vector3 cameraSize;

    public float radius = 1f;

    public Vector3 Velocity => velocity;
    public Vector3 Direction => direction;
    public Vector3 Position => transform.position;
    public float Radius => radius;
    public Vector3 CameraSize => cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        cameraSize.y = Camera.main.orthographicSize;
        cameraSize.x = cameraSize.y * Camera.main.aspect;

        direction = Random.insideUnitCircle.normalized;

        radius = this.GetComponent<SpriteRenderer>().size.x / 2;
        radius *= transform.lossyScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (useGravity)
        {
            ApplyGravity(Physics.gravity);
        }

        if (useFriction)
        {
            ApplyFriction(frictionCoeff);
        }

        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        if(velocity.sqrMagnitude > Mathf.Epsilon)
        {
            direction = velocity.normalized;
        }

        acceleration = Vector3.zero;

        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

        if (bounceOffWalls)
        {
            BounceOffWalls();
        }
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    private void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;

        ApplyForce(friction);
    }

    private void ApplyGravity(Vector3 gravityForce)
    {
        acceleration += gravityForce;
    }

    private void BounceOffWalls()
    {
        if(transform.position.x > cameraSize.x && velocity.x > 0)
        {
            velocity.x *= -1f;
        }
        if (transform.position.x < -cameraSize.x && velocity.x < 0)
        {
            velocity.x *= -1f;
        }
        if (transform.position.y > cameraSize.y && velocity.y > 0)
        {
            velocity.y *= -1f;
        }
        if (transform.position.y < -cameraSize.y && velocity.y < 0)
        {
            velocity.y *= -1f;
        }
    }
}