using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collision : MonoBehaviour
{
    bool AABB = true;
    public Sprite carS;
    public Sprite coneS;
    public GameObject car;
    public GameObject cone1;
    public GameObject cone2;
    public GameObject cone3;
    public TextMesh text;

    float carRadius;
    float coneRadius;

    // Start is called before the first frame update
    void Start()
    {
        if (carS.bounds.max.x - carS.bounds.min.x > carS.bounds.max.y - carS.bounds.min.y)
        {
            carRadius = (carS.bounds.max.x - carS.bounds.min.x) / 2;
        }
        else
        {
            carRadius = (carS.bounds.max.y - carS.bounds.min.y) / 2;
        }

        coneRadius = (coneS.bounds.max.x - coneS.bounds.min.x) / 2;


    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            if (AABB)
            {
                AABB = false;
                text.text = "Current Collision: Circular";
            }
            else
            {
                AABB = true;
                text.text = "Current Collision: AABB";
            }
        }

        float carLeftX = car.GetComponent<SpriteRenderer>().bounds.min.x;
        float carRightX = car.GetComponent<SpriteRenderer>().bounds.max.x;
        float cone1LeftX = cone1.GetComponent<SpriteRenderer>().bounds.min.x;
        float cone1RightX = cone1.GetComponent<SpriteRenderer>().bounds.max.x;

        float carBottomY = car.GetComponent<SpriteRenderer>().bounds.min.y;
        float carTopY = car.GetComponent<SpriteRenderer>().bounds.max.y;
        float cone1BottomY = cone1.GetComponent<SpriteRenderer>().bounds.min.y;
        float cone1TopY = cone1.GetComponent<SpriteRenderer>().bounds.max.y;

        float cone2LeftX = cone2.GetComponent<SpriteRenderer>().bounds.min.x;
        float cone2RightX = cone2.GetComponent<SpriteRenderer>().bounds.max.x;
        float cone2BottomY = cone2.GetComponent<SpriteRenderer>().bounds.min.y;
        float cone2TopY = cone2.GetComponent<SpriteRenderer>().bounds.max.y;

        float cone3LeftX = cone3.GetComponent<SpriteRenderer>().bounds.min.x;
        float cone3RightX = cone3.GetComponent<SpriteRenderer>().bounds.max.x;
        float cone3BottomY = cone3.GetComponent<SpriteRenderer>().bounds.min.y;
        float cone3TopY = cone3.GetComponent<SpriteRenderer>().bounds.max.y;

        if (AABB)
        {

            if(((cone1LeftX > carLeftX && cone1LeftX < carRightX) || (cone1RightX > carLeftX && cone1RightX < carRightX)) &&
                ((cone1BottomY > carBottomY && cone1BottomY < carTopY) || (cone1TopY > carBottomY && cone1TopY < carTopY)))
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            else if (((cone2LeftX > carLeftX && cone2LeftX < carRightX) || (cone2RightX > carLeftX && cone2RightX < carRightX)) &&
                ((cone2BottomY > carBottomY && cone2BottomY < carTopY) || (cone2TopY > carBottomY && cone2TopY < carTopY)))
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            else if (((cone3LeftX > carLeftX && cone3LeftX < carRightX) || (cone3RightX > carLeftX && cone3RightX < carRightX)) &&
                ((cone3BottomY > carBottomY && cone3BottomY < carTopY) || (cone3TopY > carBottomY && cone3TopY < carTopY)))
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            else
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }
        else
        {
            float distance1 = Mathf.Pow(Mathf.Pow(car.transform.position.x - cone1.transform.position.x, 2) + Mathf.Pow(car.transform.position.y - cone1.transform.position.y, 2), 0.5f);
            float distance2 = Mathf.Pow(Mathf.Pow(car.transform.position.x - cone2.transform.position.x, 2) + Mathf.Pow(car.transform.position.y - cone2.transform.position.y, 2), 0.5f);
            float distance3 = Mathf.Pow(Mathf.Pow(car.transform.position.x - cone3.transform.position.x, 2) + Mathf.Pow(car.transform.position.y - cone3.transform.position.y, 2), 0.5f);

            if (distance1 < carRadius + coneRadius)
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            else if (distance2 < carRadius + coneRadius)
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            else if (distance3 < carRadius + coneRadius)
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            }
            else
            {
                car.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }
    }
}
