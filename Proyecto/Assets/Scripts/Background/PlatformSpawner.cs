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

public class PlatformSpawner : MonoBehaviour {
    
    public GameObject[] plataformas;
    public float spawnTime = 1.23f;
    public float elapsedTime = 0f;
    public float spawnMin = 2f;
    public float spawnMax = 2.2f;
    private int control = 5;    

    // Use this for initialization
    void Start () {
        
        // se llama al metodo GenerarPlataformas()
        GenerarPlataformas();

    }

    // Update is called once per frame
    void Update () {

	}

    void GenerarPlataformas()
    {
        //Procedimiento para generar una plataforma
        while (true)
        {
            int random = Random.Range(0, plataformas.GetLength(0));
            
            //Dependiendo del random se genera una distinta plataforma
            // no se pueden generar 2 tipos de la misma plataforma juntas

            //mientras la ultima plataforma no sea igual a la que toca
            if (control != random)
            {
                control = random;
                GameObject plataforma = Instantiate(plataformas[random], transform.position, Quaternion.identity);
                Invoke("GenerarPlataformas", Random.Range(spawnMin, spawnMax));

                if (spawnMin > 0.5)
                {
                    spawnMin = spawnMin - 0.0025f;
                    spawnMax = spawnMax - 0.0025f;
                }

                break;         

            }             
        }        
    }
}
