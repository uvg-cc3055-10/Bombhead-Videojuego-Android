using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechasSpawner : MonoBehaviour
{

    public GameObject mechas;
    public float elapsedTime = 0f;
    private float spawnMin = 2f;
    private float spawnMax = 6.2f;

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

        float randomY = Random.Range(1f, 3f);

        while (true)
        {                            
            GameObject plataforma = Instantiate(mechas, new Vector2(16.42f,randomY), Quaternion.identity);
            Invoke("GenerarMechas", Random.Range(spawnMin, spawnMax));

            if (spawnMin > 0.5)
            {
                spawnMin = spawnMin - 0.0025f;
                spawnMax = spawnMax - 0.0025f;
                break;
            }
        }
    }
}
