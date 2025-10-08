using UnityEngine;
using UnityEngine.UI;

//<summary>
//Calcula cuántos pinos están caídos y muestra el puntaje en pantalla
//</summary>
public class ScoreManager : MonoBehaviour
{
    //TODO: Texto UI
    public Text textoPuntaje;

    //TODO: Variables internas
    private int puntajeActual = 0;

    [SerializeField]
    private Pin[] pinos; 

    private void Start()
    {
        textoPuntaje.text = "Tienes un millón de dólares. ";

        //PISTA: Buscar todos los objetos tipo Pin
        pinos = FindObjectsOfType<Pin>();
    }

   
    public void CalcularPuntaje()
    {
        int puntaje = 0;

        //PISTA: Revisar cada pino si está caído
        foreach (Pin pin in pinos)
        {
            if (pin.EstaCaido())
            {
                puntaje++;
            }
        }

        puntajeActual = puntaje;

        //PISTA: Actualizar texto del puntaje (validar si textoPuntaje !=null)
        if (textoPuntaje != null) textoPuntaje.text = "Puntos:" + puntajeActual;
    }
}
