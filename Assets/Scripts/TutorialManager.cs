using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private TutorialObject currentTutorialObject;
    [SerializeField] private TutorialUI tutorialUI;
    private bool buttonTutorialActive;
    private bool colliderTutorialActive;
    private bool tutorialModeActive;

    private void setCurrentTutorialObject(TutorialObject currentTutorialObject)
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

    private void showTutorial(TutorialObject tutorialObject)
    {
        setCurrentTutorialObject(tutorialObject);
        tutorialObject.onShow();
        tutorialUI.Open();
    }

    public void showColliderTutorial(TutorialObject tutorialObject)
    {
        colliderTutorialActive = true;
        showTutorial(tutorialObject);
    }

    public void showButtonTutorial(TutorialObject tutorialObject)
    {
        buttonTutorialActive = true;
        showTutorial(tutorialObject);
    }

    private void closeTutorial()
    {
        if (currentTutorialObject != null)
        {
            currentTutorialObject.onClose();
        }
        this.currentTutorialObject = null;
        tutorialUI.Close();
    }

    private void attemptCloseTutorial()
    {
        if (!colliderTutorialActive && !buttonTutorialActive)
        {
            closeTutorial();
        }
    }

    public void closeButtonTutorial()
    {
        buttonTutorialActive = false;
        attemptCloseTutorial();
    }

    public void closeColliderTutorial()
    {
        colliderTutorialActive = false;
        attemptCloseTutorial();
    }


    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Tower" || hit.collider.tag == "unit" || hit.collider.tag == "end" || hit.collider.tag == "Checkpoint")
            {
                closeColliderTutorial();
                showColliderTutorial(hit.collider.gameObject.GetComponent<TutorialObject>());
            }

            if (hit.collider.tag == "Path" || hit.collider.tag == "Untagged")
            {
                closeColliderTutorial();
            }

        }
    }
}
