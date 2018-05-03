using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower:MonoBehaviour {
	public int life = 10;
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
	private Material crystalMaterial;
	private void Start() {
		Position = transform.position;
		tower = this;
		crystalMaterial = GetComponentInChildren<MeshRenderer>().material;
	}

	private void Update() {
		if(life == 0) {
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage) {
		life -= damage;

		if(life <= 0) {
			GameOver();
		}
	}
	public void GameOver() {
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


}
