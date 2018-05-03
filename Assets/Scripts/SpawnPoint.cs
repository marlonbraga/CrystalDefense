using UnityEngine;

public class SpawnPoint:MonoBehaviour {
	float timeToSpawn;
	public GameObject enemyPrefab;

	private void Start() {
		timeToSpawn = Random.Range(0, Difficulty.GetCurrentDifficult().minRange);
	}

	private void Update() {
		GenerateEnemy();
	}

	private void GenerateEnemy() {
		if(timeToSpawn <= 0) {
			SetTimeToSpawnEnemy();
			CreateEnemyGameObject(transform);
		} else {
			timeToSpawn -= Time.deltaTime;
		}
	}

	private void CreateEnemyGameObject(Transform transform) {
		var enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
		enemy.transform.GetChild(0).GetComponent<Enemy>().life = 5;
		enemy.transform.parent = transform;
	}

	private void SetTimeToSpawnEnemy() {
		timeToSpawn = Random.Range(Difficulty.GetCurrentDifficult().minRange, Difficulty.GetCurrentDifficult().maxRange);
	}
}
