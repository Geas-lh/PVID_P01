using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoleccion : MonoBehaviour
{
    public int puntos = 100; // cada fruta da 100 puntos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // 🔹 Sumar puntuación
            GameManager.instance.AddScore(puntos);

            // 🔹 Efecto visual
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            // 🔹 Destruir después de medio segundo
            Invoke("CollectedFruit", 0.5f);
        }
    }

    public void CollectedFruit()
    {
        Destroy(gameObject);
    }
}
