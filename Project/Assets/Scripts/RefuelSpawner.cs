using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelSpawner : MonoBehaviour
{

    // Public
    public Object refuelPrefab;

	// Private
	private float lastSpawn = -500f;
	private float nextSpawn = 15;

	// Update is called once per frame
	void Update()
	{
		if (Time.time - lastSpawn > nextSpawn)
		{
			nextSpawn = Random.Range(15, 30);
			lastSpawn = Time.time;
			Instantiate(refuelPrefab);
		}
	}
}
