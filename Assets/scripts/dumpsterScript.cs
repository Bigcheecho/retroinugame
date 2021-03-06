﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumpsterScript : MonoBehaviour {
	// initial public variables
	public float enemySpawnTime, dumpsterForceTime;
	public byte enemySpawnLimit;
	public GameObject ribbonEnemy;
	public GameObject[] nonRibbonEnemy;
	public float dumpsterHorzForce, dumpsterVertForce;

	// initial private variables
	private bool dumpsterActivated = false;
	private bool dumpsterOpen = true;
	private float dumpsterTimer;
	private byte enemiesSpawned = 0;
	private Vector2 dumpsterJump;
	private GameObject spawningEnemy;
	private Rigidbody2D enemyRB;


	// Use this for initialization
	void Start () 
	{
		// sets dumpster timer to enemy spawn time
		dumpsterTimer = enemySpawnTime;

		// sets the dumpsterJump vector
		dumpsterJump = new Vector2 (dumpsterHorzForce, dumpsterVertForce);
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
			{
				ribbonEnemy.SetActive (true);
				spawningEnemy = ribbonEnemy;
			}

			// spawns normal enemy
			else 
			{
				nonRibbonEnemy[enemiesSpawned - 1].SetActive (true);
				spawningEnemy = nonRibbonEnemy[enemiesSpawned - 1];
			}

			// resets timer and keeps track of spawned enemies
			enemiesSpawned++;
			dumpsterTimer = enemySpawnTime;
		}

		// adds force to spawned enemy for jump
		if(dumpsterTimer > (enemySpawnTime-dumpsterForceTime) && !timeFreeze.timeFrozen && spawningEnemy != null)
		{
			enemyRB = spawningEnemy.GetComponent<Rigidbody2D> ();
			enemyRB.AddForce (dumpsterJump);
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D dumpsterCollider) 
	{
		// activates dumpstern when player gets near dumpster
		if (dumpsterCollider.gameObject.tag == "Player") 
			dumpsterActivated = true;
	}
}
