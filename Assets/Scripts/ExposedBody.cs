using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposedBody:MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.name);
		GetComponent<Collider>().enabled = false;
		if(collision.gameObject.GetComponent<Arrow>()) {
			collision.transform.parent = transform;
			collision.gameObject.GetComponent<ParticleSystem>().Play();
			int hitPoint = collision.gameObject.GetComponent<Arrow>().hitPoints;
			Transform t = transform;
			while(!t.GetComponent<Enemy>())
				t = t.parent;
			t.GetComponent<Enemy>().TakeDamage(hitPoint);
			transform.GetComponent<AudioSource>().Play();
		}
	}
}
