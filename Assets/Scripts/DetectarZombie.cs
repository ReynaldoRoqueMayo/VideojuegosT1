using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarZombie : MonoBehaviour
{
    public static int contador=0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            contador++;
            Debug.Log("ZOMBIE SALTADO: "+contador);
        }
    }
}
