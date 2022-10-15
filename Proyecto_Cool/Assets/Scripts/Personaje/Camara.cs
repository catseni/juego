using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Jugador;
    public Camera CamaraJuego;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Jugador != null)
        {
        CamaraJuego.transform.position = new Vector3(
            Jugador.transform.position.x,
            CamaraJuego.transform.position.y,
            CamaraJuego.transform.position.z
        );
        }
    }
}
