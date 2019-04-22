using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private string firstLevel;

    private void goToFirstLevel()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void onPlayGame()
    {
        goToFirstLevel();
    }

    public void onQuitGame()
    {
        Application.Quit();
    }

}
