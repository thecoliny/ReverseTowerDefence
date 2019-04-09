using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{


    [SerializeField] private Transform target;
    NavMeshAgent agent;
    CurrencyManagement currencyManagement;
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currencyManagement = GameObject.Find("CurrencyManager").GetComponent<CurrencyManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            Destroy(this.gameObject);
            Messenger.Broadcast(GameEvent.ENEMY_Passed);
        }
        else if (other.tag == "Projectile")
        {
            ProjectileStats stats = other.gameObject.GetComponent<ProjectileStats>();
            ReactToHit(stats.damage);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Currency")
        {
            currencyManagement.addCurrency(other.gameObject.GetComponent<CurrencyPickup>().pickupAmount);
            Destroy(other.gameObject);
        }
    }
    public void ReactToHit(float damage)
    {
        health -= damage;
        if(health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
