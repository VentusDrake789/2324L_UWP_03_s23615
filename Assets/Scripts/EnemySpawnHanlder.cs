using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab przeciwnika do zespawnowania
    public float spawnDelay = 4f; // Odstęp czasowy między spawnami

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // Pętla nieskończona, aby spawner działał ciągle
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            enemy.GetComponent<Enemy>().setRandomDirection(randomDirection);

            yield return new WaitForSeconds(spawnDelay); // Oczekiwanie określonego czasu przed następnym spawnem

        }
    }
}