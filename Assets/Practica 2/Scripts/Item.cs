using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string nombreItem = "Sin nombre";

    public Score score;

    public abstract void Recoger();

    private void Awake()
    {
      Collider collider = GetComponent<Collider>();

        if (collider != null )
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.Log("No haz convertido el colisionador en trigger o no tiene un cillider");
        }
    }
}
