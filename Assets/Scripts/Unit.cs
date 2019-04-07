using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{


    [SerializeField] private Transform target;
    NavMeshAgent agent;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.tag == "End")
        {
            Destroy(this.gameObject);
        }
    }
    public void ReactToHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
