using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    private bool isRunning;

    void Update()
    {
        // Ejemplo simple para correr
        float move = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        animator.SetBool("isRunning", isRunning);
    }
        public void TakeHit()
        {
            Debug.Log("TakeHit() llamado");
            animator.SetTrigger("hit");
        }

    }
