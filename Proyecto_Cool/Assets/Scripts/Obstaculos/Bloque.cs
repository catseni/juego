using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bloque : MonoBehaviour
{
    public int tamano;

    public void OnTriggerEnter2D(Collider2D other)
    {
        bool TienePW = other.GetComponent<Jugador>().PowerUp;

        if(TienePW == true)
        {
            Destroy(this.gameObject);
        }
    }
}
