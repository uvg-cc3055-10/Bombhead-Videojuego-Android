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

public class SueloSpawner : MonoBehaviour
{

    public GameObject suelo;
    public GameObject bombaMala;
    public float spawnTime = 1.23f;
    public float elapsedTime = 0f;
    private float contador;
    public int Random1;
    int controlBombaMala = 0;

    // Use this for initialization
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // si no ha perdido el jugador
        if (!GameController.instance.gameOver)
        {
            //si no ha llegado al tiempo de crear un nuevo suelo
            //se aumenta la variable

            if (elapsedTime < spawnTime)
            {                
                elapsedTime += Time.deltaTime;
            }

            else
            {
                //se crea un random de entre 9 y 15
                Random1 = Random.Range(9, 15);
                //se crea un suelo y se 
                StartCoroutine(CrearSuelo());
                //se reinicia elapsedTime
                elapsedTime = 0;


                if (spawnTime > 0.8f)
                {
                    spawnTime -= 0.0119952f;

                } else if (spawnTime <= 0.8f && spawnTime > 0.51f)
                {
                    spawnTime -= 0.00335f;

                } else
                {
                    spawnTime -= 0.0009215f;
                }

              
            }
        }

    }

    //metodo para crear un suelo
    IEnumerator CrearSuelo()
    {     


        if (contador == Random1)
        {
            GameController.instance.suelo = false;
            yield return new WaitForSeconds(10.0f);
            contador = 0;
        }

        float random = Random.Range(0, 100);

        if (random < 35)
        {
            Instantiate(suelo, new Vector3(20, -5, 0), Quaternion.identity);
            controlBombaMala += 1;
            
            //se crea una bomba mala justo encima del suelo, dependiendo que caso se cumpla
            if (controlBombaMala > 10)
            {
                Instantiate(bombaMala, new Vector3(20, -4, 0), Quaternion.identity);
                controlBombaMala = 0;
            }
            contador += 1;
        }
        else
        {
            GameController.instance.suelo = true;
            Instantiate(suelo, new Vector3(15, -5, 0), Quaternion.identity);
            controlBombaMala += 1;
            if (controlBombaMala>10)
            {   
                Instantiate(bombaMala, new Vector3(15, -4, 0), Quaternion.identity);
                controlBombaMala=0;
            }
            
        }
        
    }
}
