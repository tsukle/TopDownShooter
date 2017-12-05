using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Used for text manipulation.

public class GUIManager : MonoBehaviour {
    #region Variables
    public PlayerManager playerManager;
    public int count;
    #endregion

    // Find components and assign values to variables.
    void Start() {
        //Finders
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Sets the scores and counters to update consistently.
    void Update() {
        // Update ammo counter.
        if (gameObject.tag == "AmmoCounter") {
            var objText = gameObject.GetComponent<Text>();
            objText.text = playerManager.PlayerAmmoCount.ToString();
        }

        // Update fuel counter.
        if (gameObject.tag == "FuelCounter")
        {
            var objText = gameObject.GetComponent<Text>();
            objText.text = playerManager.PlayerFuelCount.ToString();
        }

        // Update lives counter.
		if (gameObject.tag == "LivesCounter")
		{
			var objText = gameObject.GetComponent<Text>();
			objText.text = playerManager.PlayerLivesCount.ToString();
		}

        // Update score counter.
		if (gameObject.tag == "ScoreCounter")
		{
			var objText = gameObject.GetComponent<Text>();
			objText.text = playerManager.PlayerScoreCount.ToString();
		}

        // Update time counter.
        if (gameObject.tag == "TimeCounter")
        {
            count = (int)Time.time; //Force it to int so that we don't get float values in the timer.
            var objText = gameObject.GetComponent<Text>();
            objText.text = (count.ToString());
        }
    }
}
