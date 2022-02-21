using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Gun : MonoBehaviour
{
    public GameObject firePoint;
    public ParticleSystem muzzle;
    public AudioClip[] gunSounds;
    private AudioSource gunNoise;

    [SerializeField] float gunRange, timeBetweenShots;
    float nextFire;
    
    void Start()
    {
       gunNoise = GetComponent<AudioSource>(); 
    }    
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
        nextFire = Time.time + timeBetweenShots;

        gunNoise.clip = gunSounds[Random.Range(0,gunSounds.Length)];
        gunNoise.pitch = Random.Range (0.8f, 1.2f);
        gunNoise.Play();
        muzzle.Play();

        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange))
        {
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 300);
            }
            if(hit.transform.tag == "Enemy")
            {
                Debug.Log ("KILL");
                StartCoroutine(hit.transform.gameObject.GetComponent<FPS_EnemyAI>().Death());
            }
        }
    }
}
