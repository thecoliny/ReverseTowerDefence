using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{


    private Transform _target;
    NavMeshAgent agent;
    CurrencyManagement currencyManagement;
    [SerializeField] private float health;
    [SerializeField] private int cost;
    [SerializeField] private float speed;
    private int slowCount;
    public float Health { get { return health; } set { health = value; } }
    public int Cost { get { return cost; } set { health = value; } }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currencyManagement = GameObject.Find("CurrencyManager").GetComponent<CurrencyManagement>();
        _target = GameObject.Find("End").transform;

        agent.speed = speed;
        slowCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(_target.position);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            Destroy(this.gameObject);
            Messenger.Broadcast(GameEvent.UNIT_PASSED);
        }
        else if (other.tag == "playGameEnd")
        {
            Destroy(this.gameObject);
            GameObject.Find("StartMenuManager").GetComponent<StartMenuManager>().onPlayGame();
        }
        else if (other.tag == "quitGameEnd")
        {
            Destroy(this.gameObject);
            GameObject.Find("StartMenuManager").GetComponent<StartMenuManager>().onQuitGame();
        }
        else if (other.tag == "Projectile")
        {
            ProjectileStats stats = other.gameObject.GetComponent<ProjectileStats>();

            if (!stats.hit)
            {
                stats.hit = true;
                ReactToHit(stats.damage);
                Destroy(other.gameObject);
            }
        }
        else if(other.tag == "SlowProjectile")
        {
            ProjectileStats stats = other.gameObject.GetComponent<ProjectileStats>();

            if (!stats.hit)
            {
                stats.hit = true;
                agent.speed = speed * stats.slowRatio;
                StartCoroutine(WaitAndUnslow());
                ReactToHit(stats.damage);
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Currency")
        {
            currencyManagement.addCurrency(other.gameObject.GetComponent<CurrencyPickup>().pickupAmount);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Checkpoint")
        {
            other.gameObject.GetComponent<CurrencyCheckpoint>().reactToCheckpointReach();
        }
        else if (other.tag == "PathL")
        {
            agent.transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        else if (other.tag == "PathU")
        {
            agent.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        else if (other.tag == "PathD")
        {
            agent.transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
    }
    public virtual void ReactToHit(float damage)
    {
        health -= damage;
        if(health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnLevelPause()
    {

    }

    private void OnLevelUnpause()
    {

    }

    private IEnumerator WaitAndUnslow()
    {
        slowCount++;
        yield return new WaitForSeconds(2.0f);
        slowCount--;
        if (slowCount == 0)
        {
            agent.speed = speed;
        }


    }
}
