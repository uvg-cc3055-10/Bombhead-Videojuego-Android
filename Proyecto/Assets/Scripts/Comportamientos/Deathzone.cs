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
using UnityEngine.SceneManagement;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public Animator explosion1;
    public Animator explosion2;
    public Animator explosion3;
    bool control = false;
    public float reloj = 0;
    Collider2D collision;

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
        //cuando la bomba muere se ejecuta lo siguiente
        if (control)
        {
            //se hace un timer y luego se regresa al menu
            reloj -= Time.deltaTime;
            if (reloj <= 0)
            {
                SceneManager.LoadScene("Principal");
            }
        }

        
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // cuando la bomba colisiona con la Deathzone
        if (collision.tag.Equals("Player"))
        {
            //se reproducen las animaciones de las explosiones
            explosion1.enabled = true;
            explosion2.enabled = true;
            explosion3.enabled = true;
            control = true;

            GameController.instance.gameOver = true;
        }
    }

}
