using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public float bulletSpeed = 10;
    float Cooldown = 1.5f;
    float lastShot = 0.0f;

    void Update ()
    {
        fire();
	}

    // Check if shots are on cooldown, if they aren't then shoot.
    void fire()
    {
        // If shot is on cooldown, do nothing.
        if (Time.time - lastShot < Cooldown)
        {
            return;
        }

        Rigidbody2D bulletShot =
            Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.4f, transform.position.z),
            transform.rotation) as Rigidbody2D;

        bulletShot.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, -bulletSpeed));

        lastShot = Time.time;
    }
}
