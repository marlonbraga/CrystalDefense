using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet:MonoBehaviour {
	public GameObject ParticleBang;
	void OnCollisionEnter(Collision collision) {
		GetComponent<Collider>().enabled = false;
		if(collision.gameObject.GetComponent<Arrow>()) {
			Instantiate(ParticleBang, collision.transform).transform.localPosition = Vector3.zero;
			collision.transform.parent = transform;
			GetComponent<AudioSource>().Play();
		}
	}
}