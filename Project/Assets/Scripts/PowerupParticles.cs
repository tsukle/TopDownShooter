using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupParticles : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}
}
