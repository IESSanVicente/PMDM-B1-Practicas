using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    float velocidadAvance = 1000f;
    float velocidadRotac = 200f;
    float xInicial, zInicial;
    int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        zInicial = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        float avance = Input.GetAxis("Vertical") * velocidadAvance * Time.deltaTime;
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotac * Time.deltaTime;

        transform.Rotate(Vector3.up, rotacion);

        transform.position += transform.forward * Time.deltaTime * avance;

    }

    public void PerderVida()
    {
        Debug.Log("Una vida menos");
        transform.position = new Vector3(xInicial, transform.position.y, zInicial);
        vidas--;

        if (vidas <= 0)
        {
            Debug.Log("Partida terminada");
            Application.Quit();
        }
    }
}
