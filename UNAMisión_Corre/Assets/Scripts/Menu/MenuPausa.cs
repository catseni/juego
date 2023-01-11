using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] public GameObject botonPausa;
    [SerializeField] public GameObject menuPausa;
    [SerializeField] public GameObject menuOpciones;
    public bool teclaPausa = false;
    public Transform jugador;
    public AudioSource clip;

    void Start() {
        Time.timeScale = 1f;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            clip.Play();
            if(teclaPausa){
                if(menuOpciones.activeInHierarchy){
                    menuOpciones.SetActive(false);
                    Pausa();
                }else{
                    Reanudar();
                }
            }else{
                if(jugador != null){
                    Pausa();
                }
            }
        }
    }

    public void Pausa()
    {
        teclaPausa = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        teclaPausa = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        teclaPausa = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Volver()
    {
        teclaPausa = false;
        SceneManager.LoadScene("MainMenu");
    }
}
