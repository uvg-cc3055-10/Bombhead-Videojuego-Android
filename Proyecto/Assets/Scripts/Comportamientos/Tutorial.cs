using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    bool control;

	// Use this for initialization
	void Start () {
        control = true;
	}
	
	// Update is called once per frame
	void Update () {		

        if (control && Input.GetMouseButtonDown(0))
        {
            control = false;
            Destroy(this.gameObject);            
        }

	}

    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }

}
