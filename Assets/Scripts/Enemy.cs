using UnityEngine;
using System.Reflection;
using System.Collections;

public class Enemy:MonoBehaviour {
	#region Fields

	public int life = 10;

	#endregion Fields

	#region UnityMethods
	void Start() {
		StartCoroutine(Spawning());
	}

	#endregion UnityMethods

	#region Methods
	private void Die() {
		StopAllCoroutines();
		Debug.Log(name + " morreu");
		GetComponent<Animator>().Play("Viking_Death");
	}
	IEnumerator WalkAtTower() {
		GetComponent<Animator>().applyRootMotion = true;
		GetComponent<Animator>().Play("Viking_Walk");
		while(Vector3.Distance(Tower.Position, transform.position) >= 1.7f) {
			transform.position = Vector3.MoveTowards(transform.position, Tower.Position, 1f * Time.deltaTime);
			yield return null;
		}
		StartCoroutine(Attacking());
	}
	IEnumerator Attacking() {
		float animationTime = 0;
		float lastTime = -1;
		bool newBlow = false;
		GetComponent<Animator>().Play("Viking_Attack");
		do {
			animationTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
			if(lastTime > animationTime)//Certifica 1 dano por ciclo de animação
				newBlow = true;
			if(animationTime >= 0.4f && newBlow) {//Momento do cair do machado na animação
				//TODO: Gerar dano ao cristal
				Debug.Log("Cristal sofre dano!");
				newBlow = false;
			}
			lastTime = animationTime;
			yield return null;
		} while(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Viking_Attack"));
	}
	IEnumerator Spawning() {
		while(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Viking_Jump")) {
			if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) {
				transform.parent.position = transform.position;
				StartCoroutine(WalkAtTower());
			}
			yield return null;
		}
	}

	public void TakeDamage(int damage) {
		Debug.Log(name + "sofreu " + damage + " de dano");
		life -= damage;
		if(life <= 0) {
			Die();
		}
	}

	#endregion Methods
}
