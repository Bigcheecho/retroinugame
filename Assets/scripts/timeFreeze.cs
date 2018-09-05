using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeFreeze : MonoBehaviour 
{

	public static bool timeFrozen;
	public float timeOfFreeze;

	private float timer = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate () 
	{
		if (Input.GetButtonDown ("Fire1") && !timeFrozen) 
		{
			timeFrozen = true;
			timer = timeOfFreeze;
		} 
		else if (timeFrozen && timer > 0) 
		{
			timer -= Time.deltaTime;
		} 
		else if (timer <= 0) 
		{
			timer = 0;
			timeFrozen = false;
		}
	}
}