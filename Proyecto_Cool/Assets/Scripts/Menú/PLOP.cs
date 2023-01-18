using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLOP : MonoBehaviour
{
    public Transform jugador;
    float Revision;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(jugador != null)
        {
            if(Vector2.Distance(jugador.position, this.transform.position) > 50)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
