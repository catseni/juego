using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDeEscena : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject[] Nivel;
    public float PunteroJuego;
    public float Generacion = 12;
    public Text TextoJuego;
    public bool Perdiste;

    // Start is called before the first frame update
    void Start()
    {
        PunteroJuego = -7;
        Perdiste = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Jugador != null)
        {

            TextoJuego.text = "Puntaje: " + Mathf.Floor(Jugador.transform.position.x/100);
        }
        else
        {
            if(!Perdiste)
            {
                Perdiste = true;
                TextoJuego.text += "\nSe terminó el juego...\n\nPresione R para intentarlo de nuevo.";
            }
            if(Perdiste)
            {
                if(Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        while( (Jugador != null) && (PunteroJuego < Jugador.transform.position.x + Generacion))
        {
            int indiceBloque = Random.Range(0, Nivel.Length - 1);
            if (PunteroJuego < 0)
            {
                indiceBloque = 2;
            }
            GameObject ObjetoBloque = Instantiate(Nivel[indiceBloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
            ObjetoBloque.transform.position = new Vector2(PunteroJuego + bloque.tamano/2, 125);
            PunteroJuego += bloque.tamano;
        }
    }
}
