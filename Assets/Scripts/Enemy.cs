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
	IEnumerator Die() {
		Debug.Log(name + " morreu");
		GetComponent<Animator>().Play("Viking_Death");
		while(!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Viking_Death")) {
			yield return new WaitForSeconds(0.001f);
		}
		while(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Viking_Death")) {
			if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) {
				yield return new WaitForSeconds(100f * Time.deltaTime);
				Destroy(gameObject);
				break;
			}
			yield return new WaitForSeconds(0.001f);
		}
	}
	IEnumerator WalkAtTower() {
		GetComponent<Animator>().applyRootMotion = true;
		GetComponent<Animator>().Play("Viking_Walk");
		while(Vector3.Distance(Tower.Position, transform.position) >= 0.04f) {//1.7f | 0.02f
			transform.position = Vector3.MoveTowards(transform.position, Tower.Position, 0.02f * Time.deltaTime);//1f | 0.01f
			transform.position = new Vector3(transform.position.x, Tower.tower.transform.position.y, transform.position.z);
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
				transform.GetComponent<AudioSource>().Play();
				Tower.tower.TakeDamage(1);
				newBlow = false;
			}
			lastTime = animationTime;
			yield return null;
		} while(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Viking_Attack"));
	}
	IEnumerator Spawning() {
		while(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Viking_Jump")) {
			if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) {
				//transform.parent.position = transform.position;
				StartCoroutine(WalkAtTower());
			}
			yield return null;
		}
	}
	public void TakeDamage(int damage) {
		Debug.Log(name + "sofreu " + damage + " de dano");
		life -= damage;
		if(life <= 0) {
			StopAllCoroutines();//If walking, Viking stop to move
			StartCoroutine(Die());
		}
	}
	#endregion Methods
}
