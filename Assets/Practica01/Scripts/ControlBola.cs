using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlBola : MonoBehaviour
{
    public Transform CamaraPrincipal;

    public Rigidbody rb;

    //Variables para apuntar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;



    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      //Expresión: mientras que haSidoLanzada sea falso puedes disparar.
        if (haSidoLanzada==false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }

    void Apuntar()
    {
        //1. Leer un input horizontal de tipo Axis te permite registrar
        // entradas con las teclas A y D, la flecha izquiera y flecha dertecha
        float inputHorizontal = Input.GetAxis("Horizontal");

        //2. Mover la bola hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        //3. Delimitar el movimiento de la bola
        Vector3 posicionActual = transform.position; //Me permite saber cual es la posición actual en la escena.

        posicionActual.x =Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicionActual;
    }

    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward* fuerzaDeLanzamiento);

        if(CamaraPrincipal !=null)
        {
            CamaraPrincipal.SetParent(transform);
        }
    }
    

} // Bienvenido a la entrada al infierno
