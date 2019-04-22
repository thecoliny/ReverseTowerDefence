using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [NonSerialized] public TutorialManager tutorialManager;
    [NonSerialized] public GameObject unit;


    public void OnPointerEnter(PointerEventData eventData)
    {
        tutorialManager.showButtonTutorial(unit.GetComponent<TutorialUnit>());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tutorialManager.closeButtonTutorial();
    }
}
