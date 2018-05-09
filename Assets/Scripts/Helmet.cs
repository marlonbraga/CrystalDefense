﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet:MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		GetComponent<Collider>().enabled = false;
		if(collision.gameObject.GetComponent<Arrow>()) {
			collision.transform.parent = transform;
			GetComponent<AudioSource>().Play();
		}
	}
}
