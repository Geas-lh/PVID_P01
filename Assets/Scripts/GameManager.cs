using UnityEngine;
using UnityEngine.UI; // Si usas el UI antiguo
using TMPro; // Si usas TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton para acceso global
    public int score = 0;
    public Text scoreText;      // Si usas el UI antiguo
    public TMP_Text scoreTMP;   // Si usas TextMeshPro

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Actualizar texto (elige según lo que uses)
        if (scoreText != null) scoreText.text = "Puntuación: " + score;
        if (scoreTMP != null) scoreTMP.text = "Puntuación: " + score;
    }
}
