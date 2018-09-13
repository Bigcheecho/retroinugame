﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumpsterScript : MonoBehaviour {
	// initial public variables
	public float enemySpawnTime;
	public int enemySpawnLimit;

	// initial private variables
	private bool dumpsterActivated = false;
	private bool dumpsterOpen = true;
	private float dumpsterTimer;
	private int enemiesSpawned = 0;


	// Use this for initialization
	void Start () 
	{
		// sets dumpster timer to enemy spawn time
		dumpsterTimer = enemySpawnTime;
	}

	// does stuff at a fixed interval
	void FixedUpdate ()
	{
		// knocks down spawn time of dumpster timer
		if (dumpsterTimer > 0 && dumpsterActivated && dumpsterOpen && !timeFreeze.timeFrozen)
			dumpsterTimer -= Time.deltaTime;

		// once timer reaches zero then spawns enemy
		else if (dumpsterActivated && dumpsterOpen && !timeFreeze.timeFrozen && enemiesSpawned < enemySpawnLimit)
		{
			// spawns ribbon enemy for tying dumpster
			if (enemiesSpawned == 0)
				dumpsterActivated = true; // to be replaced with ribbon enemy spawn

			// spawns normal enemy
			else
				dumpsterActivated = true; // to be replaced with non-ribbon enemy spawn

			// resets timer and keeps track of spawned enemies
			enemiesSpawned++;
			dumpsterTimer = enemySpawnTime;
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider dumpsterCollider) 
	{
		// activates dumpstern when player gets near dumpster
		if (dumpsterCollider.gameObject.tag == "Player") 
			dumpsterActivated = true;
	}
}