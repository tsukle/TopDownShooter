using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    #region Variables
    public float verticalSpeed = 1f;
    public float horizontalSpeed = 2f;
    #endregion

    // Run the texture offset through update to scroll the background.
    void Update () {
		//Halving each value to slow it down to a speed similar to Blue Max.
		Vector2 bgOffset = new Vector2(Time.time * horizontalSpeed / 2f, Time.time * verticalSpeed / 2f);
		//Set the texture offset to the new coordinates.
		GetComponent<Renderer>().material.mainTextureOffset = bgOffset;
	}
}
