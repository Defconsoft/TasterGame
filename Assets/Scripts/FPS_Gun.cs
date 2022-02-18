using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Gun : MonoBehaviour
{
    public GameObject firePoint;
    [SerializeField] float gunRange, timeBetweenShots;
    float nextFire;
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        nextFire = Time.time + timeBetweenShots
;
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange))
        {
            Debug.Log(hit.transform.name);
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 300);
            }
            if(hit.transform.tag == "Enemy")
            {
                Destroy(hit.transform, 0.1f);
            }
        }
    }
}