using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Atributos para BackGround.
    public Renderer fondo;
    
    // Start is called before the first frame update
    void Start()
    {
        MovimientoFondo();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoFondo();
    }
   
    void MovimientoFondo()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
    }
}
