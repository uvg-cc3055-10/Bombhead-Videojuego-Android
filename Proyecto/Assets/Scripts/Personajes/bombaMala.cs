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

public class bombaMala : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float speed = 5f;
    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        // se carga la variable almacenada en memoria
        speed = PlayerPrefs.GetFloat("velocidad") + Random.Range(3f,5f);

        //si no ha perdido el jugador
        if (!GameController.instance.gameOver)
        {
            //se mueve la bomba mala
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            //si sale de la zona visible se destruye 
            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si colisiona con la bomba buena, explota
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameController.instance.contactoBarril = true;
            Destroy(gameObject);
        }

    }


}
