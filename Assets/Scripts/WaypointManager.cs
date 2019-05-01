using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] public GameObject[] waypoints;
    [SerializeField] public List<Unit> units;
    [SerializeField] public int numUnits;

    private void Start()
    {
        for (int i = 0; i < numUnits; i++)
        {
            Unit newUnit = Instantiate<Unit>(units[Random.Range(0, units.Count)]);
            newUnit.shouldFollowWaypoint = true;
            newUnit.currentWaypoint = Random.Range(0, waypoints.Length);
            newUnit.transform.position = waypoints[newUnit.currentWaypoint].transform.position;

            do
            {
                newUnit.nextWaypoint = Random.Range(0, waypoints.Length);
            } while (newUnit.currentWaypoint == newUnit.nextWaypoint);

            newUnit.followingWaypoint = true;
        }
    }

}
