using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM_stop : MonoBehaviour
{
    [SerializeField] public Jugador Jugador;
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;

    // Start is called before the first frame update
    void Awake()
    {   
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Jugador != null){
            offset = velocidadMovimiento * Time.deltaTime;
            material.mainTextureOffset += offset;
        }
    }
}
