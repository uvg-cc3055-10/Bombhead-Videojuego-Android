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
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public int startingTime = 25;
    public float currentTime;
    public Image timeImage; 

    // Use this for initialization
    void Start () {
        
        currentTime = startingTime;
        // se crea un color verde ya que la barra de la mecha esta llena
        timeImage.color = new Color32(20,228,36,255);        

    }
	
	// Update is called once per frame
	void Update () {

        //mientras no este comenzando y este vivo
        if (currentTime >= 0 && GameController.instance.gameOver == false)
        {
            //se resta al tiempo y se reposiciona la barra
            currentTime -= Time.deltaTime;
            timeImage.fillAmount = (currentTime/25);

            //si esta dentro de cierto rango se cambia de color a la barra
            if (currentTime <= 12  && currentTime >5)
            {
                timeImage.color = new Color32(255, 216, 0, 255);

            }
             //si esta dentro de cierto rango se cambia de color a la barra
            else if (currentTime <= 5)
            {
                timeImage.color = new Color32(227, 22, 22, 255);
            }
             //si esta dentro de cierto rango se cambia de color a la barra
            else if (currentTime > 12)
            {
                timeImage.color = new Color32(20, 228, 36, 255);
            }

        }  else
        {
            GameController.instance.gameOver = true;
        }        

    }

    public void addTime(float tiempo)
    {

        if (currentTime >= 21)
        {
            currentTime = 25;
        }
        else
        {
            currentTime += tiempo;
        }
    }
}
