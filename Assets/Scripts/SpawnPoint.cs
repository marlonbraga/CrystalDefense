using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    float timeToSpawn;
    public GameObject enemyPrefab;

    private void Start()
    {
        SetTimeToSpawnEnemy();
    }

    private void Update()
    {
        GenerateEnemy();
    }

    private void GenerateEnemy()
    {
        if (timeToSpawn <= 0)
        {
            SetTimeToSpawnEnemy();
            CreateEnemyGameObject(transform.position);
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }

    private void CreateEnemyGameObject(Vector3 point)
    {
        var enemy = Instantiate(enemyPrefab, point, Quaternion.identity);
        enemy.GetComponent<Enemy>().life = 5;
        enemy.transform.parent = transform;
    }

    private void SetTimeToSpawnEnemy()
    {
        timeToSpawn = Random.Range(Difficulty.GetCurrentDifficult().minRange, Difficulty.GetCurrentDifficult().maxRange);
    }
}
