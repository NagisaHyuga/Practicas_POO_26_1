
using UnityEngine;

//<summary>
//Detecta si el pino ha sido derribado.
//</summary>
public class Pin : MonoBehaviour
{
    //TODO: Umbral de inclinación
    private float umbralCaida = 5f;

    public bool EstaCaido()
    {
        //PISTA: Calcular ángulo entre la orientación del pino y el eje vertical
        float angulo = Vector3.Angle(transform.up, Vector3.up);

        //PISTA: Retomar true si el águlo supera el umbral de caída 
        return angulo > umbralCaida;
    }
}
