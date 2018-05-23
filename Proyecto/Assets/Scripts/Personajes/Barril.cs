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
using UnityEngine;

public class Barril : MonoBehaviour
{
    Rigidbody2D rb2d;
    float speed = 5f;
    AudioSource audio;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        speed = PlayerPrefs.GetFloat("velocidad");// se carga la variable guardada en memoria

        //si no ha muerto la bomba
        if (!GameController.instance.gameOver)
        {
            //se desplaza el barril
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            // si sale de la zona visible se destruye
            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si colisiona con la bomba se termina el juego
        if (collision.gameObject.tag.Equals("Player"))
        {

            GameController.instance.contactoBarril = true;
            Destroy(gameObject);
        }
    }
}
