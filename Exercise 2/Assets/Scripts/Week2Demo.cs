using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    [SerializeField]
    int someNum = 5;

    public GameObject snowmanPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < someNum; i++)
        {
            Instantiate(snowmanPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(someNum);
    }

}
