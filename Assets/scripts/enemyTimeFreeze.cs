using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTimeFreeze : MonoBehaviour {
	// initial variables
	private Rigidbody2D enemyRB;
	private bool timeFreezeInitialization;
	private float verticalVelocity;
	private float horizontalVelocity;

	// Use this for initialization
	void Start () {
		// sets enemyRB to the enemy's rigidbody
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate () {
		// when time is frozen
		if (timeFreeze.timeFrozen && !timeFreezeInitialization) 
		{
			// stores former velocities in freeze
			verticalVelocity = enemyRB.velocity.y;
			horizontalVelocity = enemyRB.velocity.x;
			timeFreezeInitialization = true;
			// shuts off all movement
			enemyRB.gravityScale = 0;
			enemyRB.velocity = new Vector2 (0, 0);

		// when time isn't frozen
		}
		else if (timeFreezeInitialization && !timeFreeze.timeFrozen)
		{
			// turns gravity back on
			enemyRB.gravityScale = 1;
			enemyRB.velocity = new Vector2 (horizontalVelocity, verticalVelocity);
			// resets TF mechanism
			timeFreezeInitialization = false;
		}
	}


}
