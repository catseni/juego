using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int FuerzaSalto;
    public int VelocidadMovimiento;
    bool ContactoPiso = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && ContactoPiso)
        {
            ContactoPiso = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaSalto));
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadMovimiento,
            this.GetComponent<Rigidbody2D>().velocity.y
            );
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactoPiso = true;
        if(other.collider.gameObject.tag == "Obstaculo")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
