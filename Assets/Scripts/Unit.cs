using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{


    public Transform _target;
    public EndBehavior end;
    NavMeshAgent agent;
    CurrencyManagement currencyManagement;
    WaypointManager waypointManager;
    [SerializeField] private float health;
    [SerializeField] private int cost;
    [SerializeField] private float speed;
    [SerializeField] private Gradient particleGradient;
    [SerializeField] protected ParticleSystem hitParticle;
    [SerializeField] protected ParticleSystem deathParticle;

    [System.NonSerialized] public bool shouldFollowWaypoint;
    [System.NonSerialized] public bool followingWaypoint;
    [System.NonSerialized] public int currentWaypoint;
    [System.NonSerialized] public int nextWaypoint;

    private int slowCount;
    public float Health { get { return health; } set { health = value; } }
    public int Cost { get { return cost; } set { health = value; } }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currencyManagement = GameObject.Find("CurrencyManager").GetComponent<CurrencyManagement>();

        if (end) {
            _target = end.transform;
        }
        else // just for waypoints
        {
            _target = transform;
        }
        agent.speed = speed;
        slowCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (followingWaypoint)
        {
            if (waypointManager == null) {
                waypointManager = GameObject.Find("Waypoints").GetComponent<WaypointManager>();
            }

            _target = waypointManager.waypoints[nextWaypoint].transform;
        }
        agent.SetDestination(_target.position);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            other.GetComponent<EndBehavior>().OnColinCollision();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Waypoint")
        {
            if (other.transform == _target)
            {
                onWaypointPassed();
            }
        }
        else if (other.tag == "Projectile")
        {
            ProjectileStats stats = other.gameObject.GetComponent<ProjectileStats>();

            if (!stats.hit && stats.target == this)
            {
                stats.hit = true;
                ReactToHit(stats.damage);
                Destroy(other.gameObject);
            }
            
        }
        else if(other.tag == "SlowProjectile")
        {
            ProjectileStats stats = other.gameObject.GetComponent<ProjectileStats>();

            if (!stats.hit && stats.target == this)
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
    }
    public virtual void ReactToHit(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
        {
            playParticleEffect(deathParticle);

            Destroy(this.gameObject);
        }
        else
        {
            playParticleEffect(hitParticle);
        }
    }

    protected void playParticleEffect(ParticleSystem particle)
    {
        ParticleSystem newParticle = Instantiate(particle);
        newParticle.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        ParticleSystem.MainModule main = newParticle.main;
        main.startColor = particleGradient;
        newParticle.Play();
    }

    private void OnLevelPause()
    {

    }

    private void OnLevelUnpause()
    {

    }

    public void setNormalEnd()
    {

    }

    public void setCustomEnd(Transform transform)
    {
        _target = transform;
    }

    private void onWaypointPassed()
    {
        currentWaypoint = nextWaypoint;
        //transform.position = waypointManager.waypoints[currentWaypoint].transform.position;

        do
        {
            nextWaypoint = Random.Range(0, waypointManager.waypoints.Length);
        } while (currentWaypoint == nextWaypoint);

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
