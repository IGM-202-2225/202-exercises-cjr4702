using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<SpriteRenderer> creatures = new List<SpriteRenderer>();

    public int minCreatures = 10;
    public int maxCreatures = 100;
    private int numCreatures = 10;

    private float meanX;
    private float meanY;
    private float stdX;
    private float stdY;

    public SpriteRenderer elephantPrefab;
    public SpriteRenderer turtlePrefab;
    public SpriteRenderer snailPrefab;
    public SpriteRenderer octopusPrefab;
    public SpriteRenderer kangarooPrefab;

    private Vector3 minPosition;
    private Vector3 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        meanX = 0;
        meanY = 0;
        stdX = maxPosition.x / 4;
        stdY = maxPosition.y / 4;

        Spawn();
    }

    public void Spawn()
    {
        CleanUp();

        numCreatures = Random.Range(minCreatures, maxCreatures);

        for(int i = 0; i < numCreatures; i++)
        {
            creatures.Add(SpawnCreature());
        }
    }

    private SpriteRenderer ChooseRandomCreature()
    {
        float randomCreature = Random.Range(0f, 1f);
        if(randomCreature < 0.25f)
        {
            return elephantPrefab;
        }
        else if (randomCreature < 0.45f)
        {
            return turtlePrefab;
        }
        else if (randomCreature < 0.60f)
        {
            return snailPrefab;
        }
        else if (randomCreature < 0.70f)
        {
            return octopusPrefab;
        }
        else
        {
            return kangarooPrefab;
        }
        
    }

    private SpriteRenderer SpawnCreature()
    {
        Vector3 spawnPosition = new Vector3(Gaussian(meanX, stdX), Gaussian(meanY, stdY), 0);


        SpriteRenderer spawnedCreature = Instantiate(ChooseRandomCreature(), spawnPosition, Quaternion.identity);

        spawnedCreature.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

        return spawnedCreature;
    }

    private void CleanUp()
    {
        foreach (SpriteRenderer creature in creatures)
        {
            Destroy(creature.gameObject);
        }

        creatures.Clear();
    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

}
