using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	[Range(0,30)]
	public int hitPoints;
	public float thrust;
	public Rigidbody rb;
	private bool flying=true;
	void Start() {
		GetComponent<AudioSource>().Play();
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 30f);
		StartCoroutine(Flying());
	}
	void OnCollisionEnter(Collision collision) {
		rb.isKinematic = true;
		StopAllCoroutines();
		flying = false;
		GetComponent<Collider>().enabled = false;
		GetComponent<TrailRenderer>().enabled = false;
	}
	IEnumerator Flying() {
		while(flying) {
			rb.AddForce(transform.forward * thrust);
			yield return null;
		}
	}
}
