using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] public int Tipo;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            other.GetComponent<Jugador>().ActivatePowerUP();
            Destroy(gameObject);
        }
    }
}
