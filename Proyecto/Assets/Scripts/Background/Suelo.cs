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

public class Suelo : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = PlayerPrefs.GetFloat("velocidad");// Se extrae la variable guardada en memoria

        //mientras el jugador no pierda
        if (!GameController.instance.gameOver)
        {     
            //Se desplaza el suelo       
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            //si sale de la zona visible se destruye el objeto
            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }
}