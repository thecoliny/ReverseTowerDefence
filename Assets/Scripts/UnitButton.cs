using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitButton : MonoBehaviour
{
    [NonSerialized] public TutorialManager tutorialManager;
    [NonSerialized] public GameObject unit;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnShowTutorial);
    }

    public void OnShowTutorial()
    {
        tutorialManager.showColliderTutorial(unit.GetComponent<TutorialUnit>());

    }
}
