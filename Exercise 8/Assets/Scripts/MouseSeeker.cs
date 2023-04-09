using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseSeeker : Agent
{

    protected override void CalculateSteeringForces()
    {
        Vector3 mousePose = Mouse.current.position.ReadValue();
        mousePose = Camera.main.ScreenToWorldPoint(mousePose);
        mousePose.z = 0f;

        Flee(mousePose);
        
    }

}
