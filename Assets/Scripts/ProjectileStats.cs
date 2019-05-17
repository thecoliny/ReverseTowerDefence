using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    public float damage;
    public float slowRatio;
    [System.NonSerialized] public Unit target;
    [System.NonSerialized] public bool hit;

    private void Start()
    {
        hit = false;
    }
}
