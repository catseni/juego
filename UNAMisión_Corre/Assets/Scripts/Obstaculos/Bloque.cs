using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bloque : MonoBehaviour
{
    public int tamano;
    public AudioSource Destruccion;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            bool TienePW = other.GetComponent<Jugador>().PowerUp;

            if(TienePW == true){
                Destruccion.Play();
                Destroy(gameObject);
            }
        }
    }
}
