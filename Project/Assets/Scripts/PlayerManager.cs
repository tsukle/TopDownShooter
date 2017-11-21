using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Variables
    // Public
    public float verticalSpeed, horizontalSpeed;

    // Private
    private int playerFuelCount;
    private int playerAmmoCount;
    private int playerLivesCount;
    private int playerScoreCount;
    private float movementX, movementY;
    private Vector2 minBoundary, maxBoundary;

    // Unity Classes.
    public Rigidbody2D playerRB;
    public SpriteRenderer spriteRenderer;
    public Shooting shootingScript;

    // Properties
    public int PlayerFuelCount 
    {
        get { return playerFuelCount; }
        set { playerFuelCount = value; }
    }

	public int PlayerAmmoCount
	{
		get { return playerAmmoCount; }
		set { playerAmmoCount = value; }
	}

	public int PlayerLivesCount
	{
		get { return playerLivesCount; }
		set { playerLivesCount = value; }
	}

    public int PlayerScoreCount
    {
        get { return playerScoreCount; }
        set { playerScoreCount = value; }
    }
    #endregion

    // Find components and assign values to variables.
    void Start()
    {
        //Finders
        playerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootingScript = GetComponent<Shooting>();


        //Assigners
        verticalSpeed = 5f;
        horizontalSpeed = 8f;
        playerFuelCount = 10;
        playerAmmoCount = 10;
        playerLivesCount = 5;
    }

    // Take inputs and move character within bounds using speed multipliers.
    void Update()
    {
        // Only move if lives and fuel are still present.
        if (playerFuelCount != 0 && playerLivesCount != 0)
        {
            movementX = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalSpeed;
            movementY = Input.GetAxis("Vertical") * Time.deltaTime * verticalSpeed;

            minBoundary = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            maxBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            //Stop the player from going out of camera bounds (world moves player doesn't).
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minBoundary.x + 0.6f, maxBoundary.x - 0.6f), Mathf.Clamp(transform.position.y, minBoundary.y + 2.6f, maxBoundary.y - 0.5f));
            transform.Translate(movementX, movementY, 0);
        }

        // If the player runs out of fuel or lives, they die (TEMPORARILY JUST SETTING VIEWS OFF AND SCRIPTS DISABLED).
        if (playerLivesCount == 0 || playerFuelCount == 0)
        {
            spriteRenderer.enabled = false; // Don't destroy object as other objects rely on it. Stop rendering it instead.
            shootingScript.enabled = false; // Disable the shooting script.
        }

        if(playerAmmoCount == 0)
        {
            shootingScript.enabled = false;
        }
    }

    //Enemy bullet collisions
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            playerLivesCount -= 1;
            Destroy(coll.gameObject);
        }
    }

}
