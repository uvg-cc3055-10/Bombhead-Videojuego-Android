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
        speed = PlayerPrefs.GetFloat("velocidad");

        if (!GameController.instance.gameOver)
        {            
            rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (rb2d.transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }

    }
}