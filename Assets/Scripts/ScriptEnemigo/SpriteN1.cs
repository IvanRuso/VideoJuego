using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteN1 : MonoBehaviour
{
    /*
    private Vector2 SDirection;
    private Vector2 LastspriteDirection;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer; 
    */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            float angulo = transform.eulerAngles.y;
            Debug.Log("Ángulo Y del forward: " + angulo);
    }

    /*
    private void LateUpdate()// se emplea lateupdate para asegurar que el codigo en update se haya ejecutado antes de actualizar la animacion  
    {
        if ((h == 0 && v == 0) && (spriteDirection.x != 0 || spriteDirection.y != 0))
        {
            LastspriteDirection = spriteDirection;
        }
        spriteDirection = new Vector2(h, v);//como los inputs se obtienen con getAxisRaw los valores van de -1 a 1 segun la direcion que tomen
        SpriteAnimation();
    }

    private void SpriteAnimation()
    {
        animator.SetFloat("LastMoveX", LastspriteDirection.x);
        animator.SetFloat("LastMoveY", LastspriteDirection.y);
        animator.SetFloat("MoveMagnitude", spriteDirection.magnitude);
        animator.SetFloat("MoveX", spriteDirection.x);
        animator.SetFloat("MoveY", spriteDirection.y);

        if (dash)
        {
            animator.SetBool("Dashing", true);
        }
        else
        {
            animator.SetBool("Dashing", false);
        }

        if (corriendo)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
    */
}
