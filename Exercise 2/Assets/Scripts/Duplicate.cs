using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    public GameObject snowman;
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(count <= 20){
            for(int i = 0; i < (3 * count - count + 1); i++){
                Instantiate(snowman, new Vector3(-5 * count + (5 * i), 0.75f, 3 * count), Quaternion.identity);
            }
            count++;
        }
    }
}
