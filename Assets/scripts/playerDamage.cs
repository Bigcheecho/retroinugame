using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour {
	// initial variables
	public byte playerStartingHealth;
	public static byte playerHealth;

	// makes the player alive, especially after they died
	void lifeToPlayer()
	{
		// sets player health to starting health
		playerHealth = playerStartingHealth;
		// sets the player to active if it hasn't already
		gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		lifeToPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) 
		{
			// death sequence
			gameObject.SetActive (false);
		}
	}
}
