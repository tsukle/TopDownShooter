using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Destroy the object when it goes off-screen.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
