using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAzul : MonoBehaviour
{
    private float velocidad = 2;
    Vector3 posicionLocalInicial;
    private bool ataque = false, retorno = false;

    // Start is called before the first frame update
    void Start()
    {
        // Se establece el parent, aunque ya esté hecho desde el IDE.
        transform.parent = FindObjectOfType<BloqueEnemigos>().transform;

        // Se captura la posición incial con respecto al parent.
        posicionLocalInicial = transform.localPosition;

        StartCoroutine(Lanzarse());
    }

    // Update is called once per frame
    void Update()
    {
        if (ataque) {
            Debug.Log("Ataque");
            // Me lanzo hacia la posición global.
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5,-5,0), velocidad * Time.deltaTime);

            if (transform.position.y <= -4)
            {
                Debug.Log("Límite inferior");
                transform.position = new Vector3(0, 5, 0);
                ataque = false;
                retorno = true;
                StartCoroutine(Lanzarse());
            }
        } else if (retorno)
        {
            // Vuelvo a mi posición local en el grupo.
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicionLocalInicial, velocidad * Time.deltaTime);
        }
    }

    private IEnumerator Lanzarse() {
        float pausa = Random.Range(3.0f, 20.0f);
        yield return new WaitForSeconds(pausa);
        ataque = true;
        retorno = false;
    }
}
