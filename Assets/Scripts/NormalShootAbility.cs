using System.Collections;
using UnityEngine;

public class NormalShootAbility : Ability
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform spawner;        // Punto de disparo
    public float fireRate = 0.2f;    // Frecuencia de disparo
    private float nextFireTime = 0f; // Control de tiempo de recarga

    void Update()
    {
        // Disparar cuando se presiona el botón de disparo
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFireTime)
        {
            UseAbility();
            nextFireTime = Time.time + fireRate;
        }
    }

    public override void UseAbility()
    {
        // Disparo normal: Crear un proyectil
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = spawner.position;
        bullet.transform.rotation = spawner.rotation;
        Destroy(bullet, 2f);  // Destruir la bala después de 2 segundos
    }
}
