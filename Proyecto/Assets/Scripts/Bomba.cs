using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Bomba : MonoBehaviour {

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

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

        if (Input.GetKey("a"))
        {
            rb2d.AddForce(Vector2.down * 5f);
        }        

        if (Input.touchCount > 0)
        {
            Swipe(raycast);
            /*
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (raycast.collider != null)
                {
                    rb2d.AddForce(Vector2.up * jumpForce);
                }
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("ABAJOO");
            }
            */
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataforma"))
        {
            jumping = false;
        }        

    }    

    public void Swipe(RaycastHit2D raycast)
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("arriba");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    rb2d.AddForce(Vector2.down * jumpForce);
                    Debug.Log("abajo");
                }


            if (t.phase == TouchPhase.Began)
            {

                if (raycast.collider != null)
                {
                    rb2d.AddForce(Vector2.up * jumpForce);
                }

                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

        }
    }
}


