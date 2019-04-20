using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTower : TutorialObject
{
    public TutorialTower()
    {
        setObjectType("Tower");
        setStats(new List<string>{
            "Range: ",
            "Tower Rotation Speed: ",
            "Projectile Speed: ",
            "Damage: ",
            "Cooldown Time: "
        });
    }
}
