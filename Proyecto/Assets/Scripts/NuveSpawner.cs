using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuveSpawner : MonoBehaviour
{
    public GameObject nuve1;
    public GameObject nuve2;
    public GameObject nuve3;
    public GameObject nuve4;
    public float spawnTime = 0.2f;
    public float elapsedTime = 0f;
    int control = 0;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (true)
        {
            /*se incrementa el lapso de la creacion de meteriotos*/
            if (elapsedTime < spawnTime)
            {
                elapsedTime += Time.deltaTime/10;
            }
            else
            {
                control++;
                if (control==1)
                {
                    float random = Random.Range(2f, 4f);
                    Instantiate(nuve1, new Vector3(16, random, 0), Quaternion.identity);
                    elapsedTime = 0;
                }
                if (control == 2)
                {
                    float random = Random.Range(2f, 4f);
                    Instantiate(nuve2, new Vector3(16, random, 0), Quaternion.identity);
                    elapsedTime = 0;
                }
                if (control == 3)
                {
                    float random = Random.Range(2f, 4f);
                    Instantiate(nuve3, new Vector3(16, random, 0), Quaternion.identity);
                    elapsedTime = 0;
                }
                if (control == 4)
                {
                    float random = Random.Range(2f, 4f);
                    Instantiate(nuve4, new Vector3(16, random, 0), Quaternion.identity);
                    elapsedTime = 0;
                    control = 0;
                }



            }
        }

    }
}
