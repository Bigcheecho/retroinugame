using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour 
{

	// initial variables
	public byte enemyHealth;
	public byte enemyStartingHealth;

	void lifeToEnemy()
	{
		// sets player health to starting health
		enemyHealth = enemyStartingHealth;
		// sets the player to active if it hasn't already
		this.gameObject.SetActive (true);
	}

	// Use this for initialization
	void Awake () 
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
		if (Input.GetButtonDown ("Fire3") && playerInTrigger && !timeFreeze.timeFrozen && playerAttackTime.playerCanAttack) {
			// reduces enemy health by 1
			enemyHealth--;
		}
	}

	// detects player within self
	private bool playerInTrigger;

	void OnTriggerEnter2D (Collider2D enemyCollider)
	{
		if (enemyCollider.gameObject.tag == "Player") 
			playerInTrigger = true;
	}
	void OnTriggerExit2D (Collider2D enemyCollider)
	{
		if (enemyCollider.gameObject.tag == "Player") 
			playerInTrigger = false;
	}
}