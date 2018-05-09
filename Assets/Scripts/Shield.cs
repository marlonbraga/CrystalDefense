using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield:MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.GetComponent<Arrow>()) {
			collision.transform.parent = transform;
			GetComponent<AudioSource>().Play();
		}
		GetComponent<Collider>().enabled = false;
	}
}