using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    float velocidadAvance = 750;
    float velocidadRotac = 200f;
    float xInicial, zInicial;
    int vidas = 3;

    private AudioSource reproductor;
    public AudioClip[] audios;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        zInicial = transform.position.z;
        reproductor = this.GetComponent<AudioSource>();
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
        ChoqueEnemigo();

        if (vidas <= 0)
        {
            Debug.Log("Partida terminada");
            Application.Quit();
        }
    }

    public void ChoqueSalida()
    {
        reproductor.clip = audios[0];
        reproductor.Play();
    }

    public void ChoqueEnemigo()
    {
        Debug.Log("Sonido choque enemigo");
        reproductor.clip = audios[1];
        reproductor.Play();
    }
}
