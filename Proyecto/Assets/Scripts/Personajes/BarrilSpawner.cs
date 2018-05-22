using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilSpawner : MonoBehaviour
{
    public GameObject barril;

    public float spawnTime = 0.2f;
    public float elapsedTime = 0f;
    int control = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!GameController.instance.gameOver)
        {
            /*se incrementa el lapso de la creacion de meteriotos*/
            if (elapsedTime < spawnTime)
            {
                elapsedTime += Time.deltaTime / 10;
            }
            else
            {
               
                float random = Random.Range(3.8f, 4.2f);
                Instantiate(barril, new Vector3(20, random, 0), Quaternion.identity);
                elapsedTime = 0;
                
            }
        }
    }
}

