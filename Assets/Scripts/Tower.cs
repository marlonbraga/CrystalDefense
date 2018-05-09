using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower:MonoBehaviour {
	public int life = 120;
	private static Vector3 position;
	public static Tower tower;
	public static Vector3 Position {
		get {
			return position;
		}
		set {
			position = value;
		}
	}
	[SerializeField]
	private Material[] crystalMaterial;
	private void Start() {
		Position = transform.position;
		tower = this;
	}

	public void TakeDamage(int damage) {
		life -= damage;
		transform.GetChild(0).GetComponent<MeshRenderer>().material = crystalMaterial[Mathf.Max(0,((life-20)/10))];
		if(life <= 0) {
			GameOver();
		}
	}
	public void GameOver() {
		GetComponent<ParticleSystem>().Play();
		GetComponent<AudioSource>().Play();
		transform.GetChild(0).gameObject.SetActive(false);
		Enemy[] Vikigns = FindObjectsOfType(typeof(Enemy)) as Enemy[];
		foreach(var v in Vikigns) {
			v.GetComponent<Animator>().enabled = false;
			Transform t = v.transform;
			while(!t.GetComponent<SpawnPoint>())
				t = t.parent;
			t.GetComponent<SpawnPoint>().enabled = false;
		}
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
