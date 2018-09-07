/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {
	// initial variables
	public float enemyAttackTime;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per fixed time interval
	void FixedUpdate () 
	{
		while (playerInTrigger)
		{
			float timer = enemyAttackTime;
			while (enemyAttackTime > 0 && playerInTrigger)
				timer -= Time.deltaTime;
			if (playerInTrigger)
				playerDamage.playerHealth--;
		}
	}
} */