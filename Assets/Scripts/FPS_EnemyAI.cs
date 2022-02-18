using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FPS_EnemyAI : MonoBehaviour
{

    private GameObject player;
    public GameObject deathEffect;
    private NavMeshAgent agent;

    public GameObject[] models;

    public GameObject tempModel;

    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        tempModel = Instantiate (models[Random.Range (0, models.Length)], transform);
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) {
            agent.destination = player.transform.position;
        }
    }


    public IEnumerator Death() {
        alive = false;
        Destroy (agent);
        Destroy (this.GetComponent<CapsuleCollider>());
        deathEffect.SetActive (true);
        Destroy (tempModel);
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);

    }
}
