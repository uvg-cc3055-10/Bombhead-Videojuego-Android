/*
            Proyecto Final Plataformas Moviles y Juegos
    Autores: 
        Jose Cifuentes - 17509 
        Oscar Juarez   - 17315

    Fecha:
        22/05/2018 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Bomba : MonoBehaviour
{

    // Se declaran las variables
    Rigidbody2D rb2d;
    private float speed = 5f;
    public float jumpForce = 630f;
    public GameObject feet;
    public LayerMask layerMask;

    CircleCollider2D circle;

    public float fall = 2.5f;
    public float saltoBajo = 2f;

    private int doubleJump;

    public Image D1;
    public Image D2;
    public Image D3;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        doubleJump = 1;
        audio = GetComponent<AudioSource>();

        D1.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

        //si no esta topando con el suelo se crea una fuerza para abajo
        if (raycast.collider == null)
        {
            rb2d.AddForce(Vector2.down * 0.1f);
        }

        // si la velocidad es negativa
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fall - 1) * Time.deltaTime;

        }
        // si la velocidad es mayor a 0 y no ha presionado la pantalla
        else if (rb2d.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            //se hace un salto alto
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (saltoBajo - 1) * Time.deltaTime;
        }

    }

    public void salto()
    {

        //Se crea un raycast
        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

        //Si la bomba esta sobre una superficie, salta
        if (raycast.collider != null)
        {
            audio.Play();
            rb2d.AddForce(Vector2.up * jumpForce);
        } 
        
        //Si el usuario tiene dobles saltos disponibles, se realiza en doble salto y se
        //resta uno al total de dobles saltos
        if (raycast.collider == null && doubleJump>0)
        {
            audio.Play();
            rb2d.AddForce(Vector2.up * jumpForce);

            doubleJump -= 1;

            //Se hace invisible la imagen del doble salto correspondiente
            if (doubleJump==0)
            {
                D1.color = new Color32(255, 255, 255, 0);

            } else if (doubleJump == 1)
            {
                D2.color = new Color32(255, 255, 255, 0);

            } else if (doubleJump == 2)
            {
                D3.color = new Color32(255, 255, 255, 0);
            }            

        }

    }

    public void bajar()
    {
        //Se crea un raycast
        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

        //Si esta sobre una plataforma, se ejecuta la co-rutina para bajar de plataforma
        if (raycast.collider.tag.Equals("Plataforma"))
        {
            StartCoroutine(esperar());

        }
    }

    IEnumerator esperar()
    {

        //Se desactiva el collider de la bomba
        circle.enabled = false;

        //Se imprime una fuerza hacia abajo
        rb2d.AddForce(Vector2.down * 125f);

        //Se espera .12 segundos
        yield return new WaitForSeconds(0.12f);

        //Se vuelve a activar el collider, dando la ilusion que bajo la plataforma
        circle.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si la bomba choca con un dos y su variable doubleJump es menor a 4
        if (collision.gameObject.tag.Equals("Dos") && doubleJump < 4)
        {

            //Se agrega un salto doble
            doubleJump++;

            //Se muestra la imagen del dos, dependiendo de la cantidad de dobles
            //saltos que tenga
            if (doubleJump == 1)
            {
                D1.color = new Color32(255, 255, 255, 255);

            }
            else if (doubleJump == 2)
            {
                D2.color = new Color32(255, 255, 255, 255);

            }
            else if (doubleJump == 3)
            {
                D3.color = new Color32(255, 255, 255, 255);
            }
        }
    }
}