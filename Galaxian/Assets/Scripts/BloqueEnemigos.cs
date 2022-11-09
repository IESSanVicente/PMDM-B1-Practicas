using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueEnemigos : MonoBehaviour
{
    private float velocidadX = 2.0f;
    
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 0, 0);
        // Debug.Log("BE-X: " + transform.position.x);

        if ((transform.position.x <= -4.0) || (transform.position.x >= 4.0))
        {
            velocidadX = -velocidadX;
        }
    }
}
