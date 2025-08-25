using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D enemyCollider;
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public GameObject destroyParticle; // Prefab de la partícula
    public float jumpForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LosseLifeAndHit();
            CheckLife();
        }
    }

    public void LosseLifeAndHit()
    {
        lifes--;
        if (animator != null) animator.Play("hit");
    }

    public void CheckLife()
    {
        if (lifes <= 0)
        {
            if (enemyCollider != null) enemyCollider.enabled = false;
            if (spriterenderer != null) spriterenderer.enabled = false;

            // Instanciar partícula y programar su destrucción
            if (destroyParticle != null)
            {
                var fx = Instantiate(destroyParticle, transform.position, Quaternion.identity);
                var ps = fx.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    var main = ps.main;
                    // Asegura autodestrucción al terminar (por si el prefab no lo tiene configurado)
                    main.stopAction = ParticleSystemStopAction.Destroy;
                    float life = main.duration + main.startLifetime.constantMax + main.startDelay.constantMax;
                    Destroy(fx, life);
                }
                else
                {
                    Destroy(fx, 2f); // fallback si no hay ParticleSystem
                }
            }

            Invoke(nameof(EnemyDie), 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
