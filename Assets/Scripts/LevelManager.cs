using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int startingCurrency;
    public bool colinActive;
    public bool fastColinActive;
    public bool mommyActive;
    public string nextLevelName;
    public string thisLevelName;
    public string menuName;
    public int passingScore;
    public SceneController sceneController;

    public void Restart()
    {
        sceneController.Next(thisLevelName);
    }
    public void Next() {
        sceneController.Next(nextLevelName);
    }
    public void Menu()
    {
        sceneController.Next(menuName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
