using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontanaSpawner : MonoBehaviour
{

    public GameObject montana;
    public float spawnTime = 0.2f;
    public float elapsedTime = 0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (true)
        {
            /*se incrementa el lapso de la creacion de meteriotos*/
            if (elapsedTime < spawnTime)
            {
                elapsedTime += Time.deltaTime/100;
            }
            else
            {
                
                /*se crea un meteorito en una posicion al azar, partiendo desde arriba*/
                Instantiate(montana, new Vector3(37,1, 0), Quaternion.identity);
                elapsedTime = 0;
            }
        }

    }
}
