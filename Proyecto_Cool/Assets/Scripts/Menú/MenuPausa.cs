using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private bool teclaPausa = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(teclaPausa){
                Reanudar();
            }else{
                Pausa();
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
