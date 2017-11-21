using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    // Public
    //public Object particleSystem;
    public Rigidbody2D enemyRB;
    public PlayerManager playerManager;

    //Private
    private int health;

    // Use this for initialization
    void Start()
    {
        //Finders
        enemyRB = GetComponent<Rigidbody2D>();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

        //Assigners
        health = 3;
        transform.position = new Vector3(getRandomWidth(), getRandomHeight(), 6.2f);
        enemyRB.AddForce(new Vector2(-170, -68));
    }

    // Destroy this object when it goes past the player. Also remove points from a player.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
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
