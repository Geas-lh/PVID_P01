using System.Collections;
using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform[] limites;

    public float speed = 0.5f;
    public float limite_tiempoespera = 2f;

    private int i = 0;
    private int direction = 1;
    private float tiempoespera;

    private Vector2 actualPos;

    private void Start()
    {
        if (limites == null || limites.Length == 0)
        {
            Debug.LogError("No se asignaron puntos de patrulla.");
            enabled = false;
            return;
        }

        tiempoespera = 0f;
        actualPos = transform.position;

        StartCoroutine(validarMovimientoDeObjeto());
    }

    private void Update()
    {
        if (tiempoespera > 0)
        {
            tiempoespera -= Time.deltaTime;
            animator.SetBool("idle", true);
            return;
        }

        animator.SetBool("idle", false);

        transform.position = Vector2.MoveTowards(transform.position, limites[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, limites[i].position) < 0.1f)
        {
            tiempoespera = limite_tiempoespera;

            if (i == limites.Length - 1)
                direction = -1;
            else if (i == 0)
                direction = 1;

            i += direction;
        }
    }

    IEnumerator validarMovimientoDeObjeto()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            float delta = transform.position.x - actualPos.x;

            if (delta > 0.01f)
                spriteRenderer.flipX = true;   // caminando derecha → volteado
            else if (delta < -0.01f)
                spriteRenderer.flipX = false;  // caminando izquierda → sin volteo

            actualPos = transform.position;
        }
    }
}
