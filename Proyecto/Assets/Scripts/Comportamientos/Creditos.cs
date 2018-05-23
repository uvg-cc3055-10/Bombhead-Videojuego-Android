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

public class Creditos : MonoBehaviour {

    Rigidbody2D rb;
    float speed = 60f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //se mueven los creditos
        rb.transform.Translate(Vector2.up * speed * Time.deltaTime);

        //si salen de la zona visible se destruye el objeto
        if (rb.transform.position.y > 860)
        {
            Destroy(gameObject);
        }

    }
}
