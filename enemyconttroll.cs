using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyconttroll : MonoBehaviour
{
    public GameObject playerCharacter;
    public NavMeshAgent agent;

    public float health;

    private void Start()
    {
        playerCharacter = GameObject.FindWithTag("Player");
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerCharacter.transform.position) > 4f)
        {
            agent.enabled = true;
            agent.SetDestination(playerCharacter.transform.position);
        }

        else
        {
            agent.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, playerCharacter.transform.position, 3.5f * Time.deltaTime);
        }
        
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("Trap");
            Destroy(gameObject);
        }
    }
}
