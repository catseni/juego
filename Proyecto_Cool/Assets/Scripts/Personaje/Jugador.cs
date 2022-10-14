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
            print("space key was pressed");
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaSalto));
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadMovimiento,
            this.GetComponent<Rigidbody2D>().velocity.y
            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ContactoPiso = true;
        if(collision.tag == "Obstaculo")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ContactoPiso = false;
    }
}
