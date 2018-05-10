using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloSpawner : MonoBehaviour
{

    public GameObject suelo;   
    public float spawnTime = 1.23f;
    public float elapsedTime = 0f;
    private float contador;
    public int Random1;

    // Use this for initialization
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameController.instance.gameOver)
        {

            if (elapsedTime < spawnTime)
            {                
                elapsedTime += Time.deltaTime;
            }

            else
            {
                Random1 = Random.Range(9, 15);
                StartCoroutine(CrearSuelo());
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
            Instantiate(suelo, new Vector3(18, -5, 0), Quaternion.identity);
            contador += 1;
        }
        else
        {
            GameController.instance.suelo = true;
            Instantiate(suelo, new Vector3(13, -5, 0), Quaternion.identity);
        }
        
    }
}
