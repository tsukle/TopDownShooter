using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneTwoSpawner : MonoBehaviour
{
    // Public
    public Object planePrefab;

    // Private
    private float lastSpawn = -500f;
    private float nextSpawn = 6;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn > nextSpawn)
        {
            nextSpawn = Random.Range(3, 6);
            lastSpawn = Time.time;
            Instantiate(planePrefab);
        }
    }
}

