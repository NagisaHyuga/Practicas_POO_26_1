using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantasVSZombies : Item
{
    public override void Recoger()
    {
        score.PuntajeActual += 1;
        Debug.Log("Nombre de Arcade: " + nombreItem + "Año de salida: 2001");
    }
}
