﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool gameOver = false;
    public bool suelo;
    public static GameController instance;
    public bool contactoBarril = false;
    public Animator explosion1;
    public Animator explosion2;
    public Animator explosion3;
    bool control = false;
    public float reloj = 0;
    public Text tiempoTxt;
    int tiempo = 0;
    float velocidad;


    // Use this for initialization
    void Start () {
        velocidad = 5f;
        instance = this;
        explosion1 = GameObject.Find("Explosion1").GetComponent<Animator>();
        explosion2 = GameObject.Find("Explosion2").GetComponent<Animator>();
        explosion3 = GameObject.Find("Explosion3").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        velocidad=velocidad+0.001f;
        PlayerPrefs.SetFloat("velocidad", velocidad);
        tiempo++;
        tiempoTxt.text = "Tiempo: " +tiempo;



        if (contactoBarril)
        {
            Debug.Log("Barril feo");
            explosion1.enabled = true;
            explosion2.enabled = true;
            explosion3.enabled = true;
            control = true;

            GameController.instance.gameOver = true;

        }

        if (control)
        {
            reloj -= Time.deltaTime;
            if (reloj <= 0)
            {
                SceneManager.LoadScene("Principal");
            }
        }
        
    }

    public static implicit operator GameController(Deathzone v)
    {
        throw new NotImplementedException();
    }
}
