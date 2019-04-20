using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUnit : TutorialObject
{
    public TutorialUnit()
    {
        setObjectType("Unit");
        setStats(new List<string>{
            "Cost: ",
            "Health: ",
            "Speed: "
        });
    }
}
