using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private TutorialObject currentTutorialObject;
    private TutorialUI tutorialUI;
    private bool tutorialActive;

    public void setCurrentTutorialObject(TutorialObject currentTutorialObject)
    {
        this.currentTutorialObject = currentTutorialObject;

        tutorialUI.image.sprite = currentTutorialObject.sprite;
        tutorialUI.objectName.text = currentTutorialObject.objectName;
        tutorialUI.type.text = currentTutorialObject.ObjectType;
        tutorialUI.description.text = currentTutorialObject.description;
        tutorialUI.stats.text = string.Join("\n", currentTutorialObject.Stats.ToArray());
    }

    public void showTutorial(TutorialObject tutorialObject)
    {
        setCurrentTutorialObject(tutorialObject);
        tutorialActive = true;
    }

    public void closeTutorial()
    {
        this.currentTutorialObject = null;
        tutorialActive = false;
    }
}
