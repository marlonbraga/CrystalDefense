using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield:MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.GetComponent<Arrow>()) {
			GetComponent<ParticleSystem>().Play();
			collision.transform.parent = transform;
			GetComponent<AudioSource>().Play();
		}
		GetComponent<Collider>().enabled = false;
	}
}