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
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;
    public GameObject img5;
    public GameObject img6;
    int control = 0;
    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {		

        //cuando presionan la pantalla se destruye la siguiente imagen
        if (Input.GetMouseButtonDown(0))
        {
            if (control == 0)
            {
                Destroy(img1);
            }
            if (control == 1)
            {
                Destroy(img2);
            }
            if (control == 2)
            {
                Destroy(img3);
            }
            if (control == 3)
            {
                Destroy(img4);
            }
            if (control == 4)
            {
                Destroy(img5);
            }
            if (control == 5)
            {
                //si llega a la ultima imagen regresa al menu
                Destroy(img6);
                SceneManager.LoadScene("Principal");
                
            }
           

            control = control+1 ;


        }

	}

    

}
