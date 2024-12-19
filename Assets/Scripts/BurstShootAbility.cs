using UnityEngine;

public class BurstShootAbility : Ability
{
    public GameObject bulletPrefab;
    public Transform spawner;
    public float spreadAngle = 15f; // Ángulo de dispersión para la ráfaga
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    void Update()
    {
        // Disparar ráfaga cuando se presiona la tecla secundaria (por ejemplo, `F`)
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFireTime)
        {
            UseAbility();
            nextFireTime = Time.time + fireRate;
        }
    }

    public override void UseAbility()
    {
        // Disparo en ráfaga: Crear tres proyectiles con dispersión
        for (int i = -1; i <= 1; i++) // Crear tres proyectiles (centro y dos a los lados)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawner.position;

            // Ajustar el ángulo de rotación según el índice
            float angle = spawner.rotation.eulerAngles.z + i * spreadAngle;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            Destroy(bullet, 2f);  // Destruir la bala después de 2 segundos
        }
    }
}