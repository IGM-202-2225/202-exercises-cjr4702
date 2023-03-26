using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    

    public GameObject[] monsters = new GameObject[3];

    Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        foreach(GameObject monster in monsters)
        {
            Vector3 forceVector = worldPosition - monster.transform.position;
            forceVector.z = 0;

            //forceVector = forceVector.normalized;

            monster.GetComponent<PhysicsObject>().ApplyForce(forceVector);
        }
    }
}
