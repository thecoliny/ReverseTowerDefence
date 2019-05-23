using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void Next(string sceneName)
    {
        GameObject audioSourceObject = GameObject.Find("Audio Source");
        if (audioSourceObject)
        {
            AudioSource audio = audioSourceObject.GetComponent<AudioSource>();
            if (sceneName == "Menu" || sceneName == "Level Select")
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                }
            }
            else
            {
                if (audio.isPlaying)
                {
                    audio.UnPause();
                }
                else
                {
                    audio.Play();
                }

            }
        }
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
