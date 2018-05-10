using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour {

    public float fall = 2.5f;
    public float saltoBajo = 2f;

    Rigidbody2D rb;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fall - 1) * Time.deltaTime;

        } else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (saltoBajo - 1) * Time.deltaTime;
        }
        {

        }
	}
}
