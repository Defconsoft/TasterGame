using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_EnemySpawner : MonoBehaviour
{

    public GameObject enemyPf;
    public GameObject SpawnEffect;

    bool spawning ;




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && spawning == false) {
            Destroy (this.GetComponent<SphereCollider>());
            spawning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies(){
        SpawnEffect.SetActive (true);
        

        yield return new WaitForSeconds (1f);

        for (int i = 0; i < 5; i++)
        {
            GameObject clone = Instantiate (enemyPf, transform);
            clone.transform.parent = null;
            yield return new WaitForSeconds (1f);
        }

        Destroy (this.gameObject);

    }
}
