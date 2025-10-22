using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//<summary>
//Calcula cuántos pinos están caídos y muestra el puntaje en pantalla
//</summary>
public class Score : MonoBehaviour
{
    //TODO: Texto UI
    public TextMeshProUGUI textoPuntaje;

    //TODO: Variables internas
    private int puntajeActual = 0;

   public int PuntajeActual { get; set; }

    private void Start()
    {
        textoPuntaje.text = "Puntos: " + PuntajeActual;
    }

    private void Update()
    {
        textoPuntaje.text = "Puntos: " + PuntajeActual;
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        puntaje++;

        puntajeActual = puntaje;

        if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;
    }
}
