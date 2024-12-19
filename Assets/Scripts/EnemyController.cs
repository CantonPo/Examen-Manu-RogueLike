using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;      // Velocidad del enemigo
    public int health = 3;        // Vida del enemigo
    public float moveRange = 5f;  // Rango de movimiento en X (aleatorio)
    public float moveTime = 2f;   // Tiempo para moverse aleatoriamente

    private Vector2 targetPosition;

    void Start()
    {
        // Generar una posición aleatoria para mover el enemigo
        SetRandomTarget();
        // Iniciar el movimiento aleatorio
        StartCoroutine(MoveEnemy());
    }

    void Update()
    {
        // Movimiento hacia la posición objetivo
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    // Configura una nueva posición aleatoria
    void SetRandomTarget()
    {
        targetPosition = new Vector2(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
    }

    // Coroutine para mover el enemigo a una nueva posición cada cierto tiempo
    IEnumerator MoveEnemy()
    {
        while (health > 0)
        {
            // Esperar un tiempo aleatorio antes de cambiar la posición
            yield return new WaitForSeconds(moveTime);
            SetRandomTarget();
        }
    }

    // Función que maneja el daño recibido por el enemigo
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Destruir al enemigo cuando se quede sin vida
    void Die()
    {
        Destroy(gameObject);
    }
}