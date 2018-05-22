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
        
        speed = PlayerPrefs.GetFloat("velocidad") + Random.Range(3f,5f);

        if (!GameController.instance.gameOver)
        {
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameController.instance.contactoBarril = true;
            Destroy(gameObject);
        }

    }


}
