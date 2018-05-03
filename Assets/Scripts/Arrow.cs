using System.Collections;
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
		Destroy(gameObject, 30f);
	}
	void Update(){
		if(flying)
			rb.AddForce(transform.forward * thrust);
	}
	void OnCollisionEnter(Collision collision) {
		rb.isKinematic = true;
		flying = false;
		
		if(!collision.gameObject.GetComponent<Arrow>()) {
			//transform.position = collision.contacts[0].point;
			GetComponent<Collider>().enabled = false;
			Debug.Log("Arrow hits's "+ collision.gameObject.name);
		}
		if(collision.gameObject.GetComponent<Enemy>()) {
			transform.parent = collision.transform;
			collision.gameObject.GetComponent<Enemy>().TakeDamage(hitPoints);
		}
	}
}
