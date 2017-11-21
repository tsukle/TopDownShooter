using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    // Public
    public Object buildingPrefab;

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
            Instantiate(buildingPrefab);
        }
    }
}
