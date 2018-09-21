using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour 
{
	// initial variables for enemy health
	private byte enemyHealth;
	public byte enemyStartingHealth;

	// initial variables for enemy stunning
	public bool enemyStunned = false;
	public float enemyStunTime;
	private float enemyStunTimer;

	// makes the enemy alive
	void lifeToEnemy()
	{
		// sets enemy health to starting health
		enemyHealth = enemyStartingHealth;
		// resets enemyStunned values
		enemyStunned = false;
		enemyStunTimer = 0;
		// sets the enemy to active if it hasn't already
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
		// enemy health section
		if(enemyHealth <= 0 && !timeFreeze.timeFrozen) 
		{
			// death sequence
			gameObject.SetActive (false);
		}
		if (Input.GetButtonDown ("Fire3") && playerInTrigger && !timeFreeze.timeFrozen && playerAttackTime.playerCanAttack) 
		{
			// reduces enemy health by 1 & stuns enemy
			enemyHealth--;
			enemyStunned = true;
			enemyStunTimer = enemyStunTime;
		}


		// enemy stun section
		// if enemy is stunned and timer still isn't up
		if (enemyStunTimer > 0 && !timeFreeze.timeFrozen)
			enemyStunTimer -= Time.deltaTime;

		// if timer goes up after enemy's stun period
		else if (enemyStunTimer <= 0 && !timeFreeze.timeFrozen)
			enemyStunned = false;
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