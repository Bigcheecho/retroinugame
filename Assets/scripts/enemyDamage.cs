using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour 
{

	// initial variables
	public int enemyHealth;
	//private Collider2D enemyCollider;
	private bool playerInTrigger = false;

	// Use this for initialization
	void Start () 
	{
		// sets enemyCollider to the colliders of the enemy
		//Collider2D enemyCollider = gameObject.GetComponent <Collider2D>();
		// NOTE: Error with collider - likely geting the wrong collider, probably needs to be set up in array to only get trigger colliders
	}

	// Update is called once per fixed time interval
	void FixedUpdate () 
	{
		if(enemyHealth <= 0 && !timeFreeze.timeFrozen) 
		{
			// death sequence
			Destroy(gameObject);
		}
		if (Input.GetButtonDown ("Fire3") && playerInTrigger && !timeFreeze.timeFrozen) {
			// reduces enemy health by 1
			enemyHealth--;
		}
	}
	
	// Update is called while things are in the collider
	/* void OnTriggerStay2D(Collider2D enemyCollider) 
	{
		// checks if player is attacking
		if (Input.GetButtonDown ("Fire3") && enemyCollider.gameObject.tag == "Player" && !timeFreeze.timeFrozen) {
			// reduces enemy health by 1
			enemyHealth--;
		} // reset mechanism for pressing attack 
	} */

	void OnTriggerEnter2D (Collider2D enemyCollider)
	{
		if (enemyCollider.gameObject.tag == "Player") playerInTrigger = true;
	}
	void OnTriggerExit2D (Collider2D enemyCollider)
	{
		if (enemyCollider.gameObject.tag == "Player") playerInTrigger = false;
	}
}