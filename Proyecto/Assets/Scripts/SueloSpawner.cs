using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloSpawner : MonoBehaviour
{

    public GameObject suelo;   
    public float spawnTime = 1.23f;
    public float elapsedTime = 0f;
    private float contador;
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
                StartCoroutine(CrearSuelo());
                elapsedTime = 0;
            }
        }

    }

    IEnumerator CrearSuelo()
    {        

        if (contador == 8)
        {
            GameController.instance.suelo = false;
            yield return new WaitForSeconds(11.0f);            
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
