using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    public Animator animator;
    public float waitTime = 1f;
    public Transform[] moveSpots;

    private int i = 0;
    private float waitTimeCounter;
    private Vector2 previousPos;

    void Start()
    {
        waitTimeCounter = waitTime;
        previousPos = transform.position;
        StartCoroutine(CheckEnemyMoving());
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
        {
            if (waitTimeCounter <= 0)
            {
                i = (i + 1) % moveSpots.Length;  // Ciclo entre puntos
                waitTimeCounter = waitTime;
            }
            else
            {
                waitTimeCounter -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        while (true)
        {
            Vector2 currentPos = transform.position;

            if (currentPos.x < previousPos.x)
            {
                spriteRenderer.flipX = true;
                animator.SetBool("Idle", false);
            }
            else if (currentPos.x > previousPos.x)
            {
                spriteRenderer.flipX = false;
                animator.SetBool("Idle", false);
            }
            else
            {
                animator.SetBool("Idle", true);
            }

            previousPos = currentPos;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
