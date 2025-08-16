using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoleccion : MonoBehaviour
{
    // Referencia al objeto que aparecerá cuando se recolecta (por ejemplo, una fruta recolectada)
    public GameObject collectedObject;

    void Start()
    {
        // Asegura que el objeto recolectado esté desactivado al inicio
        if (collectedObject != null)
        {
            collectedObject.SetActive(false);
        }
    }

    // Detectar la colisión con el jugador
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el objeto recolectado
            if (collectedObject != null)
            {
                collectedObject.SetActive(true);
            }

            // Desactivar este objeto (la fruta)
            gameObject.SetActive(false);
        }
    }
}
