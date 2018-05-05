using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public Animator explosion1;
    public Animator explosion2;
    public Animator explosion3;
    bool control = false;
    public float reloj = 0;



    // Use this for initialization
    void Start ()
    {
        explosion1 = GameObject.Find("Explosion1").GetComponent<Animator>();
        explosion2 = GameObject.Find("Explosion2").GetComponent<Animator>();
        explosion3 = GameObject.Find("Explosion3").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (control)
        {
            reloj -= Time.deltaTime;
            if (reloj <= 0)
            {
                SceneManager.LoadScene("Principal");
            }
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            explosion1.enabled = true;
            explosion2.enabled = true;
            explosion3.enabled = true;
            control = true;
           
        }
    }

}
