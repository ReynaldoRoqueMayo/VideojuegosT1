using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private Animator animator;
    private SpriteRenderer spr;
    private static int   ANIMACION_CORRER = 1, ANIMACION_SALTAR = 2, ANIMACION_MORIR = 3;
    private bool isGround=false;
    public float speedCorrer = 10, speedSaltar = 25;
    int sentidoCorrer=1;
    private bool vivo = true;
    int estado;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!vivo) {

            animator.SetInteger("Estado", ANIMACION_MORIR);

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                Time.timeScale = 0;
            }
            


        }
        else { 
       if (DetectarZombie.contador==10)
        {
          speedCorrer =speedCorrer+8;
           DetectarZombie.contador = 0;
         }

        setCorrer(sentidoCorrer);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spr.flipX = true;
            sentidoCorrer = -1;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spr.flipX = false;
            sentidoCorrer = 1; 
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGround )
        {
            setSaltar();
         
            isGround = false;
        }
        }
    }
   
    public void setSaltar()
    {
        animator.SetInteger("Estado",ANIMACION_SALTAR);
        rb.velocity = Vector2.up * speedSaltar;   
    }
    public void setCorrer(int sentido)
    {
        animator.SetInteger("Estado", ANIMACION_CORRER);
        rb.velocity = new Vector2(speedCorrer*sentido,rb.velocity.y);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Terreno")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("choque");

            vivo = false;
        }
        
      
    }

}
