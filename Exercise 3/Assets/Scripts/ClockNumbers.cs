using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject clockNumber;
    public TextMesh[] textMeshes = new TextMesh[12];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            textMeshes[i] = Instantiate(clockNumber, new Vector3(-Mathf.Cos(i * 2.0f * Mathf.PI / 12.0f) * 2.4f, -Mathf.Sin(i * 2.0f * Mathf.PI / 12.0f) * 2.4f, 0.0f), Quaternion.identity).GetComponent<TextMesh>();
        }
        
        for(int i = 0; i < 12; i++)
        {
            textMeshes[(i + 9) % 12].text = (12 - i).ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
