using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Pickup : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            
            
            Destroy (this.gameObject);
        }
    }
}
