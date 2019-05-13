using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(EndBehavior))]
public class EndBehaviorEditor : UnityEditor.Editor
{

    UnityEditor.SerializedProperty normalEndBlock;
    UnityEditor.SerializedProperty onColinCollision;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        normalEndBlock = serializedObject.FindProperty("normalEndBlock");
        onColinCollision = serializedObject.FindProperty("onColinCollision");
    }

    public override void OnInspectorGUI()
    {
        var endBehavior = target as EndBehavior;

        UnityEditor.EditorGUILayout.PropertyField(normalEndBlock, true);
        if (!endBehavior.normalEndBlock)
        {
            UnityEditor.EditorGUILayout.PropertyField(onColinCollision, true);
        }
        this.serializedObject.ApplyModifiedProperties();
    }
}