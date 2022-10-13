using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Debug.Log("Salida!!");
            other.SendMessage("ChoqueSalida");
            Application.Quit();
        }
    }
}
