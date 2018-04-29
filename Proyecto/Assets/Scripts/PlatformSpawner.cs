using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    
    public GameObject[] plataformas;
    public float spawnTime = 1.23f;
    public float elapsedTime = 0f;
    public float spawnMin = 1f;
    public float spawnMax = 3f;
    private bool control;

    // Use this for initialization
    void Start () {

        control = true;
        GenerarPlataformas();

    }

    // Update is called once per frame
    void Update () {

        if (!GameController.instance.gameOver)
        {            

            /*
            if (elapsedTime < spawnTime)
            {
                elapsedTime += Time.deltaTime;
            }

            else if (!GameController.instance.suelo)
            {
                GenerarPlataformas();
                elapsedTime = 0;
            }
            */

        }
		
	}

    void GenerarPlataformas()
    {

        /*
        float random = Random.Range((float)0.8, (float)1.8);
        float P1 = Random.Range(-2, 0);

        if (control)
        {
            Instantiate(plataformas[Random.Range(0, plataformas.GetLength(0))], new Vector3(18, -2, 0), Quaternion.identity);
            control = false;
        }

        else
        {
        */
            Instantiate(plataformas[Random.Range(0, plataformas.GetLength(0))], transform.position, Quaternion.identity);

            /*
            Instantiate(plataformas[Random.Range(0, plataformas.GetLength(0))], new Vector3(18,P1,0), Quaternion.identity);
            Instantiate(plataformas[Random.Range(0, plataformas.GetLength(0))], new Vector3(18, P1+2, 0), Quaternion.identity);
            */

            Invoke("GenerarPlataformas", Random.Range(2f,3.5f));
        //}

        


    }
}
