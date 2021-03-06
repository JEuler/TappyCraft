﻿using UnityEngine;
using System.Collections;

public class PlayerTracker : MonoBehaviour {
	private Transform player;
	private float offsetX;

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag( "Player" ).transform;
		offsetX = transform.position.x - player.position.x;
	}

	// Update is called once per frame
	void Update() {
		if ( player != null ) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}

	}
}
