using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMapBlock : TutorialObject
{
    public void Start()
    {
        setObjectType("Block");
        setStats(new List<string>());
    }
}
