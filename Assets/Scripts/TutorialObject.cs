using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    [SerializeField] public string objectName;
    [SerializeField] public string description;
    [SerializeField] public Sprite sprite;

    public List<string> Stats { get; set; }

    public string ObjectType { get; set; }


}
