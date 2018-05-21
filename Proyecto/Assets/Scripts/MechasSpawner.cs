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

        float randomY = Random.Range(distMin, distMax);

        while (true)
        {                            
            GameObject plataforma = Instantiate(mechas, new Vector2(16.42f,(transform.position.y+(randomY))), Quaternion.identity);
            Invoke("GenerarMechas", Random.Range(spawnMin, spawnMax));

            if (spawnMin > 0.5)
            {
                spawnMin = spawnMin - 0.0012f;
                spawnMax = spawnMax - 0.0012f;
                break;
            }
        }
    }
}
