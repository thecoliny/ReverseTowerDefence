using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
//using UnityEditor.UIElements;

public class EndBehavior : MonoBehaviour
{
    public bool normalEndBlock = true;
    public UnityEvent onColinCollision;

    public void OnColinCollision()
    {
        if (!normalEndBlock)
        {
            onColinCollision.Invoke();
        }
        else
        {
            OnColinCollisionNormal();
        }
    }

    private void OnColinCollisionNormal()
    {
        Messenger.Broadcast(GameEvent.UNIT_PASSED);
    }
}
