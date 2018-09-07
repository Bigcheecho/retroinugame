using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDetection : MonoBehaviour {
	public static bool playerInTrigger;

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