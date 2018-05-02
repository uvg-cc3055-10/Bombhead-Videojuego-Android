using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {

    Rigidbody2D rb2d;
    private float speed = 5f;
    public float jumpForce = 450f;
    private bool jumping = false;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !jumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            jumping = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataforma"))
        {
            jumping = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        GameController.instance.gameOver = true;       
    }
}


