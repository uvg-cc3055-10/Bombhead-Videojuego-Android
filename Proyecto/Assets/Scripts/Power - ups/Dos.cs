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

        speed = PlayerPrefs.GetFloat("velocidad");
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && control)
        {
            audio.Play();
            sprite.color = new Color32(255, 255, 255, 0);
            control = false;
        }
    }
}
