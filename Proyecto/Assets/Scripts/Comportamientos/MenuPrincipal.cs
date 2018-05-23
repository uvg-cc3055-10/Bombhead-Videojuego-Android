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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public Text recordTxt;    
    private int record;

    // Use this for initialization
    void Start () {

        record = PlayerPrefs.GetInt("record");//extraemos la variable guardada en memoria        
        recordTxt.text = record+"";
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}    

    // metodos para cambiar de escena al presionar un boton
    public void startGame()
    {
        SceneManager.LoadScene("Mundo");
    }

    public void creditScene()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void tutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void mainMenuScene()
    {
        Debug.Log("hola");
        SceneManager.LoadScene("Principal");
    }
}
