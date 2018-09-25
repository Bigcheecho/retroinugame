using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeAttack : MonoBehaviour {
	// initial variables
	private float enemyAttackTimer;
	public float enemyAttackDelay;
	public enemyDamage damageScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per fixed interval
	void FixedUpdate () {
		// if enemy has time to attack
		if (!timeFreeze.timeFrozen && playerInTrigger && enemyAttackTimer <= 0 && !damageScript.enemyStunned) 
		{ // also need to add stun condition
			playerDamage.damagePlayer (1);
			enemyAttackTimer = enemyAttackDelay;
		}

		// enemy waiting for next attack
		else if (!timeFreeze.timeFrozen && enemyAttackTimer > 0)
			enemyAttackTimer -= Time.deltaTime;
	}

	private bool playerInTrigger;

	void OnTriggerEnter2D (Collider2D enemyCollider)
	{
		if (enemyCollider.gameObject.tag == "Player")
		{
			playerInTrigger = true;
			enemyAttackTimer = enemyAttackDelay;
		}
	}
	void OnTriggerExit2D (Collider2D enemyCollider)
	{
		if (enemyCollider.gameObject.tag == "Player") 
			playerInTrigger = false;
	}
}