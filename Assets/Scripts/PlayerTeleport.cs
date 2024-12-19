using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public float teleportDistance = 5f; // Distancia m�xima del teletransporte
    public KeyCode teleportKey = KeyCode.T; // Tecla para teletransportarse
    private Camera playerCamera; // La c�mara para obtener la posici�n del mouse

    void Start()
    {
        
        playerCamera = Camera.main;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(teleportKey))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        
        Vector3 mouseWorldPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);

        
        mouseWorldPosition.z = transform.position.z;

        
        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        // Normalizar la direcci�n para que no importe la distancia
        directionToMouse.Normalize();

        // Teletransportar al jugador una distancia limitada hacia el mouse
        transform.position += directionToMouse * teleportDistance;
    }
}