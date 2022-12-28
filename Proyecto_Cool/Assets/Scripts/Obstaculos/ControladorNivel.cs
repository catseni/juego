using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorNivel : MonoBehaviour
{
    [SerializeField] private GameObject[] SeccionesNivel;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private Transform final;
    [SerializeField] private int cantidadInicial;
    [SerializeField] private GameObject menuGaOv;
    private Transform jugador;
    public Text TextoDeJuego;
    public bool Perdiste;
    public int numAleatorio = 0;
    //public event EventHandler FinJuego;

    public bool Inicio = true;
    
    public bool Dificultad_Facil = false;
    public bool Dificultad_Medio = false;
    public bool Dificultad_Dificil = false;

    [SerializeField] public GameObject GameOver;
    [SerializeField] public MenuPausa referenciaP;

    void Start()
    {
        Perdiste = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < cantidadInicial ; i++)
        {
            if(Inicio == true){
                GenerarParteNivel(true);
                Inicio = false;
            }
            else{
                GenerarParteNivel(false);
            }
        }
    }

    void Update()
    {
        if(jugador != null)
        {
            if(Vector2.Distance(jugador.position, final.position) < distanciaMinima)
            {
                GenerarParteNivel(false);
            }
            TextoDeJuego.text = "Puntaje: " + Mathf.Floor(jugador.transform.position.x);
            
            if(Mathf.Floor(jugador.transform.position.x) == 150){
                Dificultad_Facil = false;
                Dificultad_Medio = true;
            }
            if(Mathf.Floor(jugador.transform.position.x) == 250){
                Dificultad_Medio = false;
                Dificultad_Dificil = true;
            }
            
        }
        else
        {
            if(!Perdiste)
            {
                Perdiste = true;
                TextoDeJuego.text += "\nGame Over!\nPulsa R para volver a empezar.";
            }

            if(Perdiste)
            {
                referenciaP.botonPausa.SetActive(false);
                referenciaP.menuPausa.SetActive(false);
                referenciaP.teclaPausa = false;

                if(Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private void GenerarParteNivel(bool inicio)
    {
        int a = 0;
        int b = SeccionesNivel.Length;

        if(inicio == true){
            a = 0;
            b = 2;
            Dificultad_Facil = true;
        }
        else if(Dificultad_Facil == true){
            a = 2;
            b = 6;
        }
        else if(Dificultad_Medio == true){
            a = 6;
            b = 10;
        }
        else if(Dificultad_Dificil == true){
            a = 10;
        }

        numAleatorio = UnityEngine.Random.Range(a, b);

        GameObject nivel = Instantiate(SeccionesNivel[numAleatorio], final.position, Quaternion.identity);
        final = BuscarPuntoFinal(nivel, "PuntoFinal");
    }

    private Transform BuscarPuntoFinal(GameObject parteNivel, string etiqueta)
    {
        Transform punto = null;

        foreach (Transform ubicacion in parteNivel.transform)
        {
            if(ubicacion.CompareTag(etiqueta))
            {
                punto = ubicacion;
                break;
            }
        }

        return punto;
    }

}
