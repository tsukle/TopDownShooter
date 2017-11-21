using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {
    #region Variables
    // Private
    private string tagName;

    //Classes
    private CollisionManager collisionManager;
    #endregion

    // Find components and assign values to variables.
    void Start() {
        //Finders
        collisionManager = GameObject.Find("Player/CollisionManager").GetComponent<CollisionManager>();

        //Assigners
        tagName = gameObject.tag;
    }


    // Detect collision and send data to the CollisionManager script.
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            tagName = gameObject.tag;
            collisionManager.collisionSorter(tagName, gameObject);
        }
    }
}
