using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{


    [SerializeField] private Transform target;
    private SceneController _sceneController;
    NavMeshAgent agent;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _sceneController = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        if (_sceneController == null)
        {
            Debug.Log("Error");
        }
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
            _sceneController.UpdateScore();
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
