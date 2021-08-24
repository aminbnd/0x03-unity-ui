using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Text healthText;
    public Text scoreText ;
    public float speed = 1000f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Image winLoseBG;
    public Text winLoseText;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            //Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        
        if(other.tag == "Trap")
        {
            health--;
            // Debug.Log($"Health: {health}");
            SetHealthText();
        }

        if(other.tag == "Goal")
        {
            // Debug.Log("You win!");
            congratsTextField();
        }
    }
    void SetScoreText(){
        scoreText.text = $"Score: {this.score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    
    // Displays congrats message in a Text field
    void congratsTextField()
    {
        winLoseBG.color = new Color32(0, 255, 0, 255);
        winLoseText.color = new Color32(0, 0, 0, 255);
        winLoseText.text = "You Win!";
        winLoseBG.gameObject.SetActive(true);
    }

    // Appology
    void appologyMessageTextField()
    {
        winLoseBG.color = new Color32(255, 0, 0, 255);
        winLoseText.color = new Color32(255, 255, 255, 255);
        winLoseText.text = "Game Over!";
        winLoseBG.gameObject.SetActive(true);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if(Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(speed * Time.deltaTime,0,0);
        }
    }


    void Update()
    {
        if(health == 0)
        {
            appologyMessageTextField();
            // Debug.Log("Game Over!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
