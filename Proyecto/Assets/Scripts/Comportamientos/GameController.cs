using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool suelo;
    public bool gameOver = false;
    public static GameController instance;
    public bool contactoBarril = false;
    public Animator explosion1;
    public Animator explosion2;
    public GameObject bomba;
    public Animator explosion3;
    bool control = false;
    bool controlAudio = false;
    public float reloj = 0;
    public Text tiempoTxt;
    int tiempo = 0;
    float velocidad;

    AudioSource Audio;
    public AudioClip explosionSE;

    // Use this for initialization
    void Start () {
        velocidad = 5f;
        instance = this;
        explosion1 = GameObject.Find("Explosion1").GetComponent<Animator>();
        explosion2 = GameObject.Find("Explosion2").GetComponent<Animator>();
        explosion3 = GameObject.Find("Explosion3").GetComponent<Animator>();

        Audio = gameObject.GetComponent<AudioSource>();
        explosionSE.LoadAudioData();
    }
	
	// Update is called once per frame
	void Update ()
    {     

        if (!gameOver)
        {            
            velocidad = velocidad + 0.001f;
            PlayerPrefs.SetFloat("velocidad", velocidad);
            tiempo++;
            tiempoTxt.text = (tiempo / 60) + "s";

        } else
        {

            if (!controlAudio)
            {
                reproducirExplosion(explosionSE);
                controlAudio = true;
            }
            
            Destroy(bomba);
            
            explosion1.enabled = true;
            explosion2.enabled = true;
            explosion3.enabled = true;
            control = true;

            if (tiempo/60 > PlayerPrefs.GetInt("record"))
            {
                PlayerPrefs.SetInt("record", tiempo/60);
            }
        }

        if (control)
        {
            reloj -= Time.deltaTime;
            if (reloj <= 0)
            {
                SceneManager.LoadScene("Principal");
            }
        }

        if (contactoBarril)
        {

            GameController.instance.gameOver = true;

        }               
    }

    public static implicit operator GameController(Deathzone v)
    {
        throw new NotImplementedException();
    }

    public void reproducirExplosion(AudioClip explosion)
    {
        Audio.Stop();
        Audio.clip = explosion;
        Audio.Play();
    }

}
