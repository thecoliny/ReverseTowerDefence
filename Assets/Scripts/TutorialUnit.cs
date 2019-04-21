using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialUnit : TutorialObject
{
    [SerializeField] private Unit unit;
    [SerializeField] private NavMeshAgent agent;
    private int cost;
    private float health;
    private float speed;

    public override List<string> GetStats() // Put in Getter so that gets in buttons, too
    {

        setObjectType("Unit");

        health = unit.Health;
        cost = unit.Cost;
        speed = agent.speed;

        return new List<string>{
            "Cost: " + cost,
            "Health: " + health,
            "Speed: " + speed
        };
    }


}
