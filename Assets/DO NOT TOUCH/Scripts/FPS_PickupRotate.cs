using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_PickupRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, +0.5f, 0f, Space.Self);
    }
}
