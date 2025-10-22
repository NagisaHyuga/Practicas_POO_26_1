using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    public GameObject[] luces;

    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //En vez de buscar por etiqueta, ahora vas a buscar por tipo de componente heredado

        Item itemRecogido = other.GetComponent<Item>();

        if (itemRecogido != null)
        {
            itemRecogido.Recoger();
        }

        if(other.CompareTag("arcade"))
        {
            //luz.SetActive(true);
            foreach (var luz in luces)
            {
                luz.SetActive(true);
            }

            Debug.Log("Hecha una ficha");
        }

        if (other.CompareTag("item"))
        {
            score.CalcularPuntaje();
            other.gameObject.SetActive(false);
            Debug.Log("Obtuviste un PejeDolar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("arcade"))
        {
            // luz.SetActive(false);
            foreach (var luz in luces)
            {
                luz.SetActive(false);
            }

            Debug.Log("Game Over: regresa cuando quieras. ");
        }
    }

} // Puerta al infierno
