﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool gameOver = false;
    public bool suelo;
    public static GameController instance;

    // Use this for initialization
    void Start () {

        instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
