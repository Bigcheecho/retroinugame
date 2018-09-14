using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour 
{

	// initial variables
	private byte enemyHealth;
	public byte enemyStartingHealth;

	void lifeToEnemy()
	{
		// sets player health to starting health
		enemyHealth = enemyStartingHealth;
		// sets the player to active if it hasn't already
		gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () 
	{
		lifeToEnemy ();
	}

	// Update is called once per fixed time interval
	void FixedUpdate () 
	{
		if(enemyHealth <= 0 && !timeFreeze.timeFrozen) 
		{
			// death sequence
			gameObject.SetActive (false);
		}
		if (Input.GetButtonDown ("Fire3") && enemyDetection.playerInTrigger && !timeFreeze.timeFrozen) {
			// reduces enemy health by 1
			enemyHealth--;
		}
	}

}