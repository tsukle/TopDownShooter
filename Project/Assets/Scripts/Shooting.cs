using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    // Public
    public Rigidbody2D bulletPrefab;
    public PlayerManager playerManager;
    public float bulletSpeed = 500f;
    public float Cooldown = 0.3f;
    public float lastShot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            fire();
        }
    }

    void fire()
    {
        // Check if it is off of cooldown.
        if (Time.time - lastShot < Cooldown)
        {
            return;
        }

        // If it's not on cooldown, fire a bullet and remove one from the ammo counter.
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        Rigidbody2D bulletShot = Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.4f, 
                                                                       transform.position.z), transform.rotation) as Rigidbody2D;
        bulletShot.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, bulletSpeed - 200));
        playerManager.PlayerAmmoCount = Mathf.Clamp(playerManager.PlayerAmmoCount - 1, 0, 300);
        lastShot = Time.time;
    }
}
