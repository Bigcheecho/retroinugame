using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {


	// initial variables
	public float speed;
	public float jumpStrength;
	private Rigidbody2D playerRB;
	private float verticalVelocity;
	private float verticalInput;

	// keeps track of initialization of time freezes within this program
	private bool timeFreezeInitialization = false;

	// allows jump to be held
	private bool isHoldingJump = false;

	// keeps track of time jump is occuring
	private float jumpTimer;
	public float jumpTime;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody2D> ();
	}

	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate () {
		// Store the current horizontal input in the float moveHorizontal as well as vertical velocity in float verticalVelocity
		float moveHorizontal = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");

		// when time is frozen
		if (timeFreeze.timeFrozen) {
			// keeps track of vertical speed upon start of freeze
			if (!timeFreezeInitialization){
				verticalVelocity = playerRB.velocity.y;
				timeFreezeInitialization = true;
			}
			// shuts off all movement
			playerRB.gravityScale = 0;
			playerRB.velocity = new Vector2(0, 0);

		// when time isn't frozen
		} else {
			// resets time freeze initialization and turns gravity back on
			if (timeFreezeInitialization) {
				// turns gravity back on
				playerRB.gravityScale = 1;
				playerRB.velocity = new Vector2 (moveHorizontal * speed, verticalVelocity);
				// resets TF mechanism
				timeFreezeInitialization = false;
			
			// once time freeze intialization is reset
			} else {
				// sets movement speed in player
				playerRB.velocity = new Vector2 (moveHorizontal * speed, playerRB.velocity.y);
			}
				
			if (isHoldingJump){
				jumpTimer -= Time.deltaTime;
				if (jumpTimer <= 0){
					isHoldingJump = false;
				}
			}
		}
	}

	void OnCollisionStay2D (Collision2D collision) {
		if (verticalInput > 0 && (collision.gameObject.tag == "Floor" || isHoldingJump)){
			Vector2 jumpInput = new Vector2 (0, jumpStrength);
			playerRB.AddForce(jumpInput);
			if (!isHoldingJump) {
				isHoldingJump = true;
				jumpTimer = jumpTime;
			}
		}
	}
}