using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Jugador : MonoBehaviour
{
    [Header("Referencias")]
    private Rigidbody2D rigidBody2D;
    public AudioSource MusicaFondo;
    public AudioSource Aparecer;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float VelocidadMovimiento;
    public Vector2 input;

    [Header("Salto")]
    [SerializeField] private float FuerzaSalto;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private LayerMask Suelo;
    public AudioSource SonidoSalto;

    private bool contactoSuelo;
    private bool saltar;

    [Header("SaltoRegulado")]
    [Range(0, 1)][SerializeField] private float multiplicadorTerminarSalto;
    [SerializeField] private float multiplicadorGravedad;
    private float escalarGravedad;
    private bool botonSaltoArriba = true;

    [Header("Agarcharse")]
    [SerializeField] private Transform controladorTecho;
    [SerializeField] private float radioTecho;
    [SerializeField] private float multVelocidadAgachado;
    [SerializeField] private Collider2D colisionadorAgachado;
    public AudioSource SonidoAgachado;
    private bool agachado = false;
    private bool agachar = false;
    
    [Header("Animacion")]
    private Animator animador;

    public event EventHandler FinJuego;

    [Header("PowerUp")]
    [SerializeField] public bool PowerUp = false;
    public AudioSource SonidoPW;
    public AudioSource MusicaPW;

    public float timer;
    public float inicioPW, finPW;
    public bool contadorPW = false;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        escalarGravedad = rigidBody2D.gravityScale;
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        animador.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        rigidBody2D.velocity = new Vector2(VelocidadMovimiento, rigidBody2D.velocity.y);

        if(Input.GetButton("Jump") && contactoSuelo == true)
        {
            saltar = true;
        }

        if(Input.GetButtonUp("Jump"))
        {
            BotonSaltoArriba();
        }

        contactoSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0, Suelo);
        animador.SetBool("contactoSuelo", contactoSuelo);

        if(input.y < 0){
            agachar = true;
        }else{
            agachar = false;
        }

        if( (timer >= finPW) && (contadorPW == true) ){
            SonidoPW.Stop();
            PowerUp = false;
            contadorPW = false;
            MusicaPW.Stop();
            MusicaFondo.Play();
        }
    }

    private void FixedUpdate()
    {
        if (saltar && botonSaltoArriba && contactoSuelo && (agachado == false))
        {
            SonidoSalto.Play();
            Saltar();
        }

        if(rigidBody2D.velocity.y < 0 && !contactoSuelo)
        {
            rigidBody2D.gravityScale = escalarGravedad * multiplicadorGravedad;
        }
        else
        {
            rigidBody2D.gravityScale = escalarGravedad;
        }

        animador.SetBool("contactoSuelo", contactoSuelo);
        animador.SetBool("Agachar", agachado);

        if(contactoSuelo == true){
            Mover(agachar);
        }

        saltar = false;
    }

    public void Mover(bool agachar){
        
        if(!agachar){
            if(Physics2D.OverlapCircle(controladorTecho.position, radioTecho, Suelo)){
                agachar = true;
            }
        }
        
        if(agachar){
            if(!agachado){
                agachado = true;
                SonidoAgachado.Play();
            }
            //mover *= multVelocidadAgachado;
            colisionadorAgachado.enabled = false;
        }else{
            colisionadorAgachado.enabled = true;
            if(agachado)
            {
                agachado = false;
            }
        }
        
    }

    public void Saltar()
    {
        rigidBody2D.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
        contactoSuelo = false;
        saltar = false;
        botonSaltoArriba = false;
    }

    public void BotonSaltoArriba()
    {
        if (rigidBody2D.velocity.y > 0)
        {
            rigidBody2D.AddForce(Vector2.down * rigidBody2D.velocity.y * (1 - multiplicadorTerminarSalto), ForceMode2D.Impulse);
        }

        botonSaltoArriba = true;
        saltar = false;
    }

    public void ActivatePowerUP()
    {
        MusicaFondo.Stop();
        SonidoPW.Play();
        MusicaPW.Play();
        inicioPW = timer;
        finPW = timer + 7;
        contadorPW = true;
        PowerUp = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        Gizmos.DrawWireSphere(controladorTecho.position, radioTecho);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Obstaculo"){
            if(PowerUp == false){
                MusicaFondo.Stop();
                FinJuego?.Invoke(this, EventArgs.Empty);
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}