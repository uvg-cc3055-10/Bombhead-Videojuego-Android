using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Bomba : MonoBehaviour
{

    Rigidbody2D rb2d;
    private float speed = 5f;
    public float jumpForce = 630f;
    public GameObject feet;
    public LayerMask layerMask;

    CircleCollider2D circle;

    public float fall = 2.5f;
    public float saltoBajo = 2f;

    private int doubleJump;

    public Image D1;
    public Image D2;
    public Image D3;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        doubleJump = 1;
        audio = GetComponent<AudioSource>();

        D1.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

        if (raycast.collider == null)
        {
            rb2d.AddForce(Vector2.down * 0.1f);
        }

        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fall - 1) * Time.deltaTime;

        }
        else if (rb2d.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (saltoBajo - 1) * Time.deltaTime;
        }

    }

    public void salto()
    {

        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

        if (raycast.collider != null)
        {
            audio.Play();
            rb2d.AddForce(Vector2.up * jumpForce);
        } 
        

        if (raycast.collider == null && doubleJump>0)
        {
            audio.Play();
            rb2d.AddForce(Vector2.up * jumpForce);

            doubleJump -= 1;

            if (doubleJump==0)
            {
                D1.color = new Color32(255, 255, 255, 0);

            } else if (doubleJump == 1)
            {
                D2.color = new Color32(255, 255, 255, 0);

            } else if (doubleJump == 2)
            {
                D3.color = new Color32(255, 255, 255, 0);
            }            

        }

    }

    public void bajar()
    {
        RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

        if (raycast.collider.tag.Equals("Plataforma"))
        {
            StartCoroutine(esperar());

        }
    }

    IEnumerator esperar()
    {

        circle.enabled = false;

        rb2d.AddForce(Vector2.down * 125f);

        yield return new WaitForSeconds(0.12f);

        circle.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Dos") && doubleJump < 4)
        {
            doubleJump++;

            if (doubleJump == 1)
            {
                D1.color = new Color32(255, 255, 255, 255);

            }
            else if (doubleJump == 2)
            {
                D2.color = new Color32(255, 255, 255, 255);

            }
            else if (doubleJump == 3)
            {
                D3.color = new Color32(255, 255, 255, 255);
            }
        }
    }
}