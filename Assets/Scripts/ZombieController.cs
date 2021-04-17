using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody2D rbz;
    private SpriteRenderer sprz;
    public float speedZombie = 4;
    void Start()
    {
        rbz = GetComponent<Rigidbody2D>();
        sprz = GetComponent<SpriteRenderer>();
        sprz.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
  
        rbz.velocity = new Vector2(speedZombie*-1,rbz.velocity.y) ;
        
       
       
        
    }
}
