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
    private Transform jugador;
    public Text TextoDeJuego;
    public bool Perdiste;

    void Start()
    {
        Perdiste = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < cantidadInicial ; i++)
        {
            GenerarParteNivel();
        }
    }

    void Update()
    {
        if(jugador != null)
        {
            if(Vector2.Distance(jugador.position, final.position) < distanciaMinima)
            {
                GenerarParteNivel();
            }
            TextoDeJuego.text = "Puntaje: " + Mathf.Floor(jugador.transform.position.x);
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
                if(Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private void GenerarParteNivel()
    {
        int numAleatorio = Random.Range(0, SeccionesNivel.Length);
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
