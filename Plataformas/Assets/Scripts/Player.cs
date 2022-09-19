using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad = 2;
    [SerializeField] float velocidadSalto = 20;
    float xInicial, yInicial;
    float alturaPersonaje;
    private Animator anim;
    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        anim = gameObject.GetComponent<Animator>();

        sonido = GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        if ((horizontal > 0.1f) || (horizontal < -0.1f))
        {
            anim.Play("PersonajeCorriendo");
        }

        float salto = Input.GetAxis("Jump");
        if (salto > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
            anim.Play("PersonajeSaltando");
            AudioSource.PlayClipAtPoint(sonido.clip, Camera.main.transform.position);

            if (hit.collider != null)
            {
                float distanciaAlSuelo = hit.distance;
                bool tocandoElSuelo = distanciaAlSuelo < alturaPersonaje;

                if (tocandoElSuelo)
                {
                    Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
                    GetComponent<Rigidbody2D>().AddForce(fuerzaSalto);
                }
            }
        }
    }

    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
