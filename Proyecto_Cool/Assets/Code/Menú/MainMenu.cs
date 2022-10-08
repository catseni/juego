using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void EscenaInicio()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EscenaOpciones()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Salir()
    {
        Application.Quit();
    }

}
