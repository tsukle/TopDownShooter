using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneOneSpawner : MonoBehaviour {
    // Public
    public Object planePrefab;

    // Private
    private float lastSpawn = -500f;
    private float nextSpawn = 3;
	
	// Update is called once per frame
	void Update () {
        if(Time.time - lastSpawn > nextSpawn)
        {
            nextSpawn = Random.Range(1, 4);
            lastSpawn = Time.time;
            Instantiate(planePrefab);
        }
	}
}
