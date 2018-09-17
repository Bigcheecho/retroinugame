using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeFreeze : MonoBehaviour 
{
	// initial timer settings
	public static bool timeFrozen;
	public float timeOfFreeze;
	public float freezeDelay;

	private float freezeTimer = 0;
	private float delayTimer = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate () 
	{
		// when the input is received and delay timer is finished
		if (Input.GetButtonDown ("Fire1") && !timeFrozen && delayTimer <= 0) {
			timeFrozen = true;
			freezeTimer = timeOfFreeze;
		} 

		// counting down while time is frozen
		else if (timeFrozen && freezeTimer > 0)
			freezeTimer -= Time.deltaTime;

		// after time is unfrozen
		else if (freezeTimer <= 0 && timeFrozen) {
			freezeTimer = 0;
			delayTimer = freezeDelay;
			timeFrozen = false;
		}

		// counts down the delay for time freezing
		if (delayTimer > 0)
			delayTimer -= Time.deltaTime;
	}
}