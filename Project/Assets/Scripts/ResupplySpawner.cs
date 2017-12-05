using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResupplySpawner : MonoBehaviour
{

    // Public
    public Object resupplyPrefab;

	// Private
	private float lastSpawn = -500f;
	private float nextSpawn = 15;

	// Update is called once per frame
	void Update()
	{
        Debug.Log("Time: " + Time.time + "\n" + "Subtracted: " + (Time.time - lastSpawn));
		if (Time.time - lastSpawn > nextSpawn)
		{
			nextSpawn = Random.Range(5, 15);
			lastSpawn = Time.time;
			Instantiate(resupplyPrefab);
		}
	}
}
