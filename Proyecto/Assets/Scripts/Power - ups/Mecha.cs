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

public class Mecha : MonoBehaviour
{
    Rigidbody2D rb2d;
    float speed = 5f;
    Timer timer;
    AudioSource audio;
    SpriteRenderer sprite;
    bool control;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timer = GetComponent<Timer>();
        timer = FindObjectOfType<Timer>();
        audio = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        control = true;
    }

    // Update is called once per frame
    void Update()
    {        
        //se varga la variable almacenada en memoria
        speed = PlayerPrefs.GetFloat("velocidad");

        //mientras este viva la bomba
        if (!GameController.instance.gameOver)
        {
            /*movemos la mecha de posicion */
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            /*si la mecha sale del area visible se destruye el objeto*/
            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //si la bomba colisiona con la mecha
        if (collision.gameObject.tag.Equals("Player") && control)
        {
            audio.Play();//suena efecto
            timer.addTime(5.1f);// se agrega tiempo de vida a la bomba
            sprite.color = new Color32(255, 255, 255, 0);
            control = false;
        }      
    }

}