using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour {

    Rigidbody2D rb;
    float speed = 60f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (rb.transform.position.y > 860)
        {
            Destroy(gameObject);
        }

    }
}
