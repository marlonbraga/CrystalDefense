using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposedBody:MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		GetComponent<Collider>().enabled = false;
		if(collision.gameObject.GetComponent<Arrow>()) {
			collision.transform.parent = transform;
			int hitPoint = collision.gameObject.GetComponent<Arrow>().hitPoints;
			Transform t = transform;
			while(!t.GetComponent<Enemy>()) {
				t = t.parent;
			}
			t.GetComponent<Enemy>().TakeDamage(hitPoint);
			transform.GetComponent<AudioSource>().Play();
		}
	}
}
