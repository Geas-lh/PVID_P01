using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 2f;
    public SpriteRenderer spriteRenderer;

    private Transform targetPoint;
    private bool movingRight = true;

    void Start()
    {
        // Empezamos yendo hacia la derecha
        targetPoint = rightPoint;
    }

    void Update()
    {
        if (targetPoint == null) return;

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);

        float distance = Vector2.Distance(transform.position, targetPoint.position);

        if (distance < 0.1f)
{
    Debug.Log("Cambio de dirección");
    movingRight = !movingRight;
    targetPoint = movingRight ? rightPoint : leftPoint;
    if (spriteRenderer != null)
        spriteRenderer.flipX = !movingRight;
}

    }
}
