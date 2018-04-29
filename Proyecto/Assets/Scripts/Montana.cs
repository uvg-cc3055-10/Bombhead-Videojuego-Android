using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montana : MonoBehaviour
{
    Rigidbody2D rb2d;
    float speed = 1.5f;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameController.instance.gameOver)
        {
            /*movemos el meteorito de posicion */
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            /*si el meteorito sale del area visible se destruye el objeto*/
            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }
}
