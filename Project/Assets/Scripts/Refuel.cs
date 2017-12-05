using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuel : MonoBehaviour
{
    // Public
    public GameObject particles;
    public Rigidbody2D refuelRB;
    public PlayerManager playerManager;

    // Use this for initialization
    void Start()
    {
        //Finders
        refuelRB = GetComponent<Rigidbody2D>();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

        //Assigners
        transform.position = new Vector3(getRandomWidth(), getRandomHeight(), 6.2f);
        refuelRB.AddForce(new Vector2(-170, -68));
	}

	// Destroy this object when it goes past the player. Also remove points from a player.
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			GameObject inst = Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z),
									  Quaternion.identity);
			Destroy(inst, 1f);
		}
	}


	float getRandomHeight()
	{
		return Random.Range(3, 10);
	}

	float getRandomWidth()
	{
		return Random.Range(7, 10);
	}
}
