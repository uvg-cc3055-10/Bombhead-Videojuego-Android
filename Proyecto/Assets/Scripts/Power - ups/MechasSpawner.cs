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

public class MechasSpawner : MonoBehaviour
{

    public GameObject mechas;
    public float elapsedTime = 0f;
    public float spawnMin = 2f;
    public float spawnMax = 2.2f;
    public float distMin;
    public float distMax;

    // Use this for initialization
    void Start()
    {
        GenerarMechas();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerarMechas()
    {
        //se crea una posicion en y random
        float randomY = Random.Range(distMin, distMax);

        while (true)
        {    // se crea una mecha justo arriba de una plataforma                 
            GameObject plataforma = Instantiate(mechas, new Vector2(16.42f,(transform.position.y+(randomY))), Quaternion.identity);
            Invoke("GenerarMechas", Random.Range(spawnMin, spawnMax));

            if (spawnMin > 0.5)
            {
                spawnMin = spawnMin - 0;
                spawnMax = spawnMax - 0;
                break;
            }
        }
    }
}
