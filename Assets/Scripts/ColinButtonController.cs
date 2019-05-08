using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColinButtonController : MonoBehaviour
{
    [SerializeField] private UnityEvent buttonEvent;
    [SerializeField] private string buttonText;
    // Start is called before the first frame update
    void Start()
    {
        EndBehavior end = gameObject.GetComponentInChildren<EndBehavior>();
        end.onColinCollision = buttonEvent;

        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = buttonText;
    }
}
