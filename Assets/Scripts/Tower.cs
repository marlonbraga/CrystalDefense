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
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
