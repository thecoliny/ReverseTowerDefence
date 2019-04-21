using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTower : TutorialObject
{
    private TowerAttack towerAttack;
    private float range;
    private float towerRotationSpeed;
    private float projectileSpeed;
    private float damage;
    private float cooldownTime;

    public void Start()
    {
        towerAttack = gameObject.GetComponent<TowerAttack>();
        range = towerAttack.range;
        towerRotationSpeed = towerAttack.towerRotationSpeed;
        projectileSpeed = towerAttack.projectileSpeed;
        damage = towerAttack.projectilePrefab.GetComponent<ProjectileStats>().damage;
        cooldownTime = towerAttack.cooldownTime;

        setObjectType("Tower");
        setStats(new List<string>{
            "Range: " + range,
            "Rot Speed: " + towerRotationSpeed,
            "Proj Speed: " + projectileSpeed,
            "Damage: " + damage,
            "Cooldown: " + cooldownTime
        });
    }
}
