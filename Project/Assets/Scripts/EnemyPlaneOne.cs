using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneOne : MonoBehaviour {
    // Public
    public GameObject particles;
    public Rigidbody2D enemyRB;
    public PlayerManager playerManager;

    //Private
    private int health;

    public int Health{
        get { return health; }
        set { health = value; }
    }

	// Use this for initialization
	void Start () 
    {
        //Finders
        enemyRB = GetComponent<Rigidbody2D>();
		playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

        //Assigners
        health = 3;
        transform.position = new Vector2(getRandomWidth(), getRandomHeight());
        enemyRB.AddForce(new Vector2(Random.Range(-100, -150), Random.Range(-100, -150)));
	}

    // Destroy this object when it goes past the player. Also remove points from a player.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Handle collisions from player, bullets etc...
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerManager.PlayerLivesCount = Mathf.Clamp(playerManager.PlayerLivesCount - 1, 0, 3); // Remove a life from the player.
            Destroy(gameObject); // Destroy the enemy plane.
			GameObject inst = Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z),
									  Quaternion.identity);
			Destroy(inst, 1f);

        }

        if(col.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }

    void Update()
    {
		// If the enemy dies, it gets destroyed and the player gets five points.
		if(health <= 0)
        {
            Destroy(gameObject);
			GameObject inst = Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z),
									  Quaternion.identity);
			Destroy(inst, 1f);
            playerManager.PlayerScoreCount = Mathf.Clamp(playerManager.PlayerScoreCount + 5, 0, 9999999);
        }
    }

    float getRandomHeight()
    {
        return Random.Range(3,10);
    }

	float getRandomWidth()
	{
		return Random.Range(7, 10);
	}
}
