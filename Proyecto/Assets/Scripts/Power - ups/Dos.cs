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

public class Dos : MonoBehaviour {

    Rigidbody2D rb2d;
    float speed = 5f;
    AudioSource audio;
    SpriteRenderer sprite;
    bool control;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        control = true;
    }

    // Update is called once per frame
    void Update()
    {
        // se carga la variable almacenada en memoria
        speed = PlayerPrefs.GetFloat("velocidad"); 

        //mientras el jugador no pierda
        if (!GameController.instance.gameOver)
        {
            /*movemos el dos de posicion */
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            /*si el dos sale del area visible se destruye el objeto*/
            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //si la bomba hagarra un 2
        if (collision.gameObject.tag.Equals("Player") && control)
        {
            audio.Play();
            sprite.color = new Color32(255, 255, 255, 0);
            control = false;
        }
    }
}
