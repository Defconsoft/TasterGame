using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPS_PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;
    public Slider healthSlider;
    public Text scoreText;
    public int score = 0;
    void Update()
    {
        healthSlider.value = playerHealth;
        if(playerHealth <= 0)
        {
            GameOver();
        }    
        if(transform.position.y <= -1f)
        {
            GameOver();
        }
        scoreText.text = score.ToString();
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
