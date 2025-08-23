using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
    [Header("Punto al que el jugador será enviado")]
    public Transform posicionDeReinicio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (posicionDeReinicio != null)
            {
                other.transform.position = posicionDeReinicio.position;
            }
            else
            {
                Debug.LogWarning("No se ha asignado la posición de reinicio.");
            }
        }
    }
}
