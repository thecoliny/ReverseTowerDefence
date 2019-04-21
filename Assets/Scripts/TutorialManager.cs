using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private TutorialObject currentTutorialObject;
    [SerializeField] private TutorialUI tutorialUI;
    private bool tutorialActive;
    private bool tutorialModeActive;

    public void setCurrentTutorialObject(TutorialObject currentTutorialObject)
    {
        this.currentTutorialObject = currentTutorialObject;

        if (currentTutorialObject != null)
        {
            tutorialUI.image.sprite = currentTutorialObject.sprite;
            tutorialUI.objectName.text = currentTutorialObject.objectName;
            tutorialUI.type.text = currentTutorialObject.getObjectType();
            tutorialUI.description.text = currentTutorialObject.description;
            tutorialUI.stats.text = string.Join("\n", currentTutorialObject.GetStats().ToArray());
        }
        else
        {
            Debug.LogWarning("Warning! Current Tutorial Object Set to null.");
        }
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

    public void activateTutorialMode() {
        tutorialModeActive = true;
    }

    public void deactivateTutorialMode()
    {
        tutorialModeActive = false;
    }

    public void toggleTutorialMode()
    {
        tutorialModeActive = !tutorialModeActive;
    }

    public bool isTutorialModeActive() { return tutorialModeActive; }
}
