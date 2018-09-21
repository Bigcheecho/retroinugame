using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackTime : MonoBehaviour {
	// initial public variables
	public static bool playerCanAttack = true;
	public float playerAttackDelay;

	// initial private variables
	private float playerAttackTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per fixed time interval
	void FixedUpdate () {
		// checks if playerAttackTimer is greater than 0 and sets playerCanAttack to false
		if (playerAttackTimer > 0)
			playerCanAttack = false;

		// when the player inputs and is capable of attacking
		if (playerCanAttack && Input.GetButtonDown ("Fire3") && !timeFreeze.timeFrozen) 
		{
			playerAttackTimer = playerAttackDelay;
		} 
		// when the player isn't capable of attacking and the timer isn't up
		else if (!playerCanAttack && (playerAttackTimer > 0) && !timeFreeze.timeFrozen)
			playerAttackTimer -= Time.deltaTime;

		// when the attack timer runs out
		else if (!playerCanAttack && !timeFreeze.timeFrozen)
			playerCanAttack = true;
			
	}
}
