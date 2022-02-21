using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Pickup : MonoBehaviour
{
    public int scoreNum = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            
            scoreNum++;
            Debug.Log(scoreNum);
            GameObject.Find("Player").GetComponent<FPS_PlayerHealth>().score++;
            Destroy (this.gameObject, 0.01f);

        }
    }
    
}
