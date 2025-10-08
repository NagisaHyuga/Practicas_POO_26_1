using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlBola : MonoBehaviour
{
    public Rigidbody rb;

    //Variables para apuntar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;



    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    //TODO: Referencia a la cámara y score
    public CameraFollow cameraFollow;
    public ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        //PISTA: Obtener el componente Rigidbody de esta bola
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Expresion:mientras que haSidoLanzada sea falso puedes disparar.
        if (haSidoLanzada == false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LanzarBola();
            }
        }
    }

    void Apuntar()
    {
        //1.leer un input horizontal de tipo Axis te permite registrar
        // entradas co las teclas A y D
        //PISTA: Obtener el movimiento horizontal(-1 a 1)
        float inputHorizontal = Input.GetAxis("Horizontal");

        //2 mOVER HACIA LOS LADOS LA BOLA
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        //3 delimitar movimiento de la boola transform.position permite ver la posicion actual de la bola en la escena
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicionActual;
    }

    void LanzarBola()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);
        //Comprobar si el rigidbody existe antes de usarlo
        //Esta comrpobacion evita errores NullReferenceException
        //Si olvidamos arrastrar el rigidbody o el componente fue eliminado
        //el sistema no deberia intentar usarlo

        //PISTA: Iniciar seguimiento de la camara
        if (cameraFollow != null) cameraFollow.IniciarSeguimiento();
      }

    void OnCollisionEnter(Collision collision)
    {
        //si colisiona con un pino
        if (collision.gameObject.CompareTag("Pin"))
        {
            //detener el seguimiento de camara
            if (cameraFollow != null) cameraFollow.DetenerSeguimiento();
                //calcular puntaje tras un pequenio retraso
            if (scoreManager != null) Invoke("CalcularPuntaje", 0f);
        }
    }
    void CalcularPuntaje()
    {
        //Llamar al ScoreManager para actulizar puntos
       scoreManager.CalcularPuntaje();
    }
} //Bienvenido a la entrada al infierno