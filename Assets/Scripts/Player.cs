using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float correrSpeed = 2;
    public float saltarSpeed = 2;
    public bool gransalto = true;
    public float multiplicador = 2f;          // recomendado >1 para efecto visible
    public float bajo_multiplicador = 2f;     // recomendado >1 para efecto visible

    Rigidbody2D rb2D;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = 0f;

        // Movimiento horizontal
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            move = 1f;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            move = -1f;
        }

        rb2D.velocity = new Vector2(move * correrSpeed, rb2D.velocity.y);

        // Voltear sprite según dirección
        if (move > 0) spriteRenderer.flipX = false;
        if (move < 0) spriteRenderer.flipX = true;

        // Enviar parámetro al Animator
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Salto
        if (Input.GetKey("space") && Ground.IsGround)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, saltarSpeed);
        }

        // Mejorar efecto salto
        if (gransalto)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (multiplicador - 1) * Time.deltaTime;
            }
            else if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (bajo_multiplicador - 1) * Time.deltaTime;
            }
        }
    }
}
