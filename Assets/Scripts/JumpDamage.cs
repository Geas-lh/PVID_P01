using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D enemyCollider;
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public GameObject destroyParticle;
    public float jumpForce = 2.5f;
    public int lifes = 2;

    public void OnCollisionEnter2D(Collision2D collision)
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
        animator.Play("hit");
    }

    public void CheckLife()
    {
        if (lifes <= 0)
        {
            if (destroyParticle != null)
            {
                destroyParticle.transform.SetParent(null);
                destroyParticle.SetActive(true);
            }

            spriterenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
