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

public class Fondito : MonoBehaviour
{
    Rigidbody2D rb2d;
    float speed = 1.1f;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // si n ha perdido el jugador...
        if (!GameController.instance.gameOver)
        {
            /*movemos el fondo de posicion */
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            /*si el fondo sale del area visible se traslada el objeto*/
            if (rb2d.transform.position.x < -174)
            {
                rb2d.transform.Translate(new Vector3(346, -0.07f,0));
            }
        }

    }
}
