using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public int startingTime = 25;
    public float currentTime;    
    public Image timeImage;    

    // Use this for initialization
    void Start () {
        
        currentTime = startingTime;
        timeImage.color = new Color32(20,228,36,255);        

    }
	
	// Update is called once per frame
	void Update () {

        if (currentTime >= 0 && GameController.instance.gameOver == false)
        {
            currentTime -= Time.deltaTime;
            timeImage.fillAmount = (currentTime / 25);

            if (currentTime <= 12  && currentTime >5)
            {
                timeImage.color = new Color32(255, 216, 0, 255);

            }
            else if (currentTime <= 5)
            {
                timeImage.color = new Color32(227, 22, 22, 255);
            }
            else if (currentTime > 12)
            {
                timeImage.color = new Color32(20, 228, 36, 255);
            }

        }  else
        {
            GameController.instance.gameOver = true;
        }        

    }

    public void addTime(float tiempo)
    {

        if (currentTime >= 21)
        {
            currentTime = 25;
        }
        else
        {
            currentTime += tiempo;
        }
    }
}
