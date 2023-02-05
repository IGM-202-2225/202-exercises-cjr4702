using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    public GameObject clockHand;
    private float turnAmount = -(2.0f * Mathf.PI);
    public bool useDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useDeltaTime)
        {
            float rotation = Time.deltaTime * turnAmount;
            clockHand.transform.Rotate(0.0f, 0.0f, rotation, Space.World);
        }
        else
        {
            clockHand.transform.Rotate(0.0f, 0.0f, turnAmount, Space.World);
        }
    }
}
