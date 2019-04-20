using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUnit : TutorialObject
{

    // Start is called before the first frame update
    void Start()
    {
        ObjectType = "Unit";
        Stats = new List<string>{
            "Cost: ",
            "Health: ",
            "Speed: "
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
