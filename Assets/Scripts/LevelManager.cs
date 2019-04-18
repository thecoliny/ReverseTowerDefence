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
    public int passingScore;
    private SceneController _sceneController;

    public void Start()
    {
        _sceneController = this.transform.GetComponentInChildren<SceneController>();
    }

    public void Next() {
        _sceneController.Next(nextLevelName);
    }

}
