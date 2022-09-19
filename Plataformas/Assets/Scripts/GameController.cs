using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int puntos;
    private int vidas;
    private int itemsRestantes;
    private int nivelActual;

    public TextMeshProUGUI textoGameOver;

    void Start()
    {
        itemsRestantes = FindObjectsOfType<Moneda>().Length;
        puntos = FindObjectOfType<GameStatus>().puntos;
        vidas = FindObjectOfType<GameStatus>().vidas;
        nivelActual = FindObjectOfType<GameStatus>().nivelActual;

        textoGameOver.enabled = false;
    }

    public void AnotarItemRecogido()
    {
        puntos += 10;
        FindObjectOfType<GameStatus>().puntos = puntos;
        Debug.Log("puntos: " + puntos);

        itemsRestantes--;
        Debug.Log("items restantes: " + itemsRestantes);
        if (itemsRestantes <= 0)
            AvanzarNivel();
    }

    private void AvanzarNivel()
    {
        nivelActual++;
        if (nivelActual > FindObjectOfType<GameStatus>().nivelMasAlto)
            nivelActual = 1;
        FindObjectOfType<GameStatus>().nivelActual = nivelActual;
        SceneManager.LoadScene("Nivel" + nivelActual);
    }

    public void PerderVida()
    {
        vidas--;
        FindObjectOfType<GameStatus>().vidas = vidas;
        FindObjectOfType<Player>().SendMessage("Recolocar");
        Debug.Log("Una vida menos. Quedan: " + vidas);
        if (vidas <= 0)
        {
            TerminarPartida();
        }
    }

    private void TerminarPartida()
    {
        Debug.Log("Partida terminada");
        StartCoroutine(VolverAlMenuPrincipal());
    }

    private IEnumerator VolverAlMenuPrincipal()
    {
        textoGameOver.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f); // 3 segundos de tiempo real
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
