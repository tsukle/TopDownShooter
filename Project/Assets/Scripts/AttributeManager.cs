using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour {
    #region Variables
    // Private
    private int reFuelAmount;
    private int reSupplyAmount;
    private int count;

    //Classes
    public PlayerManager playerManager;
    #endregion

    // Find components and assign values to variables.
    void Start() {
        //Finders
        playerManager = GetComponentInParent<PlayerManager>();

        //Assigners
        reFuelAmount = 2;
        reSupplyAmount = 20;

    }

    // Run the Fuel timer to tick down the fuel.
    void FixedUpdate() {
        count++;
        if (count == (50 * 15)) { //Fixed update is called every 0.02 seconds. Count hitting 50 essentially means 1 second has passed (.02 * 50 = 1).
            playerManager.PlayerFuelCount = Mathf.Clamp(playerManager.PlayerFuelCount -= 1, 0, 10); //Clamp this so it doesn't go into minus numbers
            count = 0;
        }
    }

    // Re-Fuels the players plane.
    public void ReFuel() {
        playerManager.PlayerFuelCount = Mathf.Clamp(playerManager.PlayerFuelCount + reFuelAmount, 0, 10);
        Debug.Log("Plane has been refueled: " + playerManager.PlayerFuelCount);
    }

    // Re-Supplies the players bomb count.
    public void ReSupply() {
        playerManager.PlayerAmmoCount = Mathf.Clamp(playerManager.PlayerAmmoCount + reSupplyAmount, 0, 40);
        Debug.Log("Plane has been resupplied: " + playerManager.PlayerAmmoCount);
    }

    // Start the Refuel Coroutine.
    public void CoRouteReFuel(object[] parms) {
        StartCoroutine("RaiseReFuel", parms);
    }

    // Start the Resupply Coroutine.
    public void CoRouteReSupply(object[] parms)
    {
        StartCoroutine("RaiseReSupply", parms);
    }

    // Raises the size of the reFuelling for 30 seconds.
    public IEnumerator RaiseReFuel(object[] parameters) {
        Debug.Log("Started the buff (ReFuel)");
        int amount = (int)parameters[0];
        reFuelAmount += amount;
        yield return new WaitForSeconds(30);
        Debug.Log("Stopped the buff (ReFuel)");
        reFuelAmount -= amount;
    }

    // Raises the size of the reFuelling for 30 seconds.
    public IEnumerator RaiseReSupply(object[] parameters)
    {
        Debug.Log("Started the buff (Resupply)");
        int amount = (int)parameters[1];
        reSupplyAmount += amount;
        yield return new WaitForSeconds(30);
        Debug.Log("Stopped the buff (Resupply)");
        reSupplyAmount -= amount;
    }
}
