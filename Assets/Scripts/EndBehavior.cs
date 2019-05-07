using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.UIElements;
using UnityEditor;
using UnityEditor.Experimental.UIElements;

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

[CustomEditor(typeof(EndBehavior))]
public class EndBehaviorEditor : Editor
{

    SerializedProperty normalEndBlock;
    SerializedProperty onColinCollision;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        normalEndBlock = serializedObject.FindProperty("normalEndBlock");
        onColinCollision = serializedObject.FindProperty("onColinCollision");
    }

    public override void OnInspectorGUI()
    {
        var endBehavior = target as EndBehavior;

        EditorGUILayout.PropertyField(normalEndBlock, true);
        if (!endBehavior.normalEndBlock)
        {
            EditorGUILayout.PropertyField(onColinCollision, true);
        }
        this.serializedObject.ApplyModifiedProperties();
    }
}
