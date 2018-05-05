using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    
    public GameObject[] plataformas;
    public float spawnTime = 1.23f;
    public float elapsedTime = 0f;
    public float spawnMin = 1f;
    public float spawnMax = 3f;
    private int control = 5;    

    // Use this for initialization
    void Start () {
        
        GenerarPlataformas();

    }

    // Update is called once per frame
    void Update () {

	}

    void GenerarPlataformas()
    {

        while (true)
        {
            int random = Random.Range(0, plataformas.GetLength(0));            
            
            if (control != random)
            {
                control = random;
                GameObject plataforma = Instantiate(plataformas[random], transform.position, Quaternion.identity);
                Invoke("GenerarPlataformas", Random.Range(2f, 2.2f));
                break;

            }             
        }        
    }
}
