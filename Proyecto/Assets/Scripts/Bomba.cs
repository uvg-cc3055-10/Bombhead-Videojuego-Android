using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bomba : MonoBehaviour {

    Rigidbody2D rb2d;
    private float speed = 5f;
    public float jumpForce = 550f;
    private bool jumping = false;
    public GameObject feet;
    public LayerMask layerMask;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);
        if (raycast.collider == null)
        {
            rb2d.AddForce(Vector2.down * 0.1f);
        }            
        //rb2d.transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {            
            //RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);
            if (raycast.collider != null)
            {
                rb2d.AddForce(Vector2.up * jumpForce);
            }            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataforma"))
        {
            jumping = false;
        }

        if (collision.gameObject.tag.Equals("Barril"))
        {
            GameController.instance.contactoBarril = true;
        }


    }        
}


