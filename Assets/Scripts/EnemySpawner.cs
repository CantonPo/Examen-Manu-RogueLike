using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab del enemigo
    public float spawnInterval = 1f; // Intervalo de tiempo entre spawns

    void Start()
    {
        // Iniciar la generación de enemigos
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Crear un enemigo en una posición aleatoria dentro de la pantalla
        float spawnX = Random.Range(-8f, 8f);
        float spawnY = Random.Range(-4f, 4f);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}