using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlJugador : MonoBehaviour
{
    //Movimiento
    public float velocidad = 5f; //velocidad de movimiento del jugador
    public float gravedad = -9.8f; //Controlar la velocidad o fuerza de gravedad en el juego o propiamente del jugador
    private CharacterController controller; //Pieza de lego que nos permite el movimiento en el juego
    private Vector3 velocidadVertical; //Nos va a permitir saber que tan rapido caemos


    //VariableVista
    public Transform camara; //Es para registrar que camara va a funcionar como los ojos del jugador
    public float sensibilidadMouse = 200f; //Que tan rapido se va a mover el mouse para voltear a ver en diferentes direcciones 
    private float rotacionXVertical = 0f; //Es para indicar cuantos grados va a poder voltear a ver hacia arriba o hacia abajo el jugador

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        //Esta invocaion funciona para buscar la pieza de lego caracterController

        //Esta linea bloquea el puntero del mouse en los límites de la pamtalla
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        ManejadorMovimiento();
        ManejadorVista();
    }

    void ManejadorVista()
    {
        //1. leer el input del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        //2. Construir la rotación horizontal
        transform.Rotate(Vector3.up * mouseX);

        //3. Registro de la rotación vertical
        rotacionXVertical -= mouseY;

        //4. Limitar la rotacion vertical
        Mathf.Clamp(rotacionXVertical, -90f, 90f);

        //5. Aplicar la rotación
                               // son los ejes     (x,            y, z)
        camara.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0);

    }

    void ManejadorMovimiento()
    {
        //1. leer input de movimiento (WASD o la flecha de direccion)
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //2. crear el vector de movimiento
           //Se almacena de forma local el registro de direccion de movimiento
        Vector3 direccion = transform.right * inputX + transform.forward * inputZ;

        //3. mover el caracterController
        controller.Move(direccion*velocidad*Time.deltaTime);

        //4. aplicar la gravedad
            //Registro si estoy en el piso para un futuro comportamiento de salto
        if(controller.isGrounded && velocidadVertical.y <0)
        {
            velocidadVertical.y = -2f; //una pequeña fuerza para mantenerlo pegado al piso
        }

        //Aplicamos la aceleración de la gravedad
        velocidadVertical.y += gravedad * Time.deltaTime;

        //Movemos el controller hacia abajo
        controller.Move(velocidadVertical*Time.deltaTime);
    }

}
