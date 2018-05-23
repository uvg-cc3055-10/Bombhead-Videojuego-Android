using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DosSpawner : MonoBehaviour {

    public GameObject dos;
    public float elapsedTime = 0f;
    public float spawnMin = 20f;
    public float spawnMax = 40f;
    public float distMin=-3f;
    public float distMax=3.5f;

    // Use this for initialization
    void Start()
    {
        GenerarDos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerarDos()
    {

        float randomY = Random.Range(distMin, distMax);

        while (true)
        {
            GameObject plataforma = Instantiate(dos, new Vector2(16.42f, (transform.position.y + (randomY))), Quaternion.identity);
            Invoke("GenerarDos", Random.Range(spawnMin, spawnMax));

            if (spawnMin > 0.5)
            {
                spawnMin = spawnMin -0;
                spawnMax = spawnMax -0;
                break;
            }
        }
    }
}
