﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	[SerializeField][Range(0,30)]
	private int hitPoints;
	public float thrust;
	public Rigidbody rb;
	private bool flying=true;
	void Start() {
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 2f);
	}
	void Update () {
		if(flying)
			rb.AddForce(-transform.right * thrust);
	}
	void OnCollisionEnter(Collision collision) {
		flying = false;
		if(collision.gameObject.GetComponent<Enemy>()) {
			collision.gameObject.GetComponent<Enemy>().TakeDamage(hitPoints);
		}
		Destroy(gameObject, .2f);
	}
}
