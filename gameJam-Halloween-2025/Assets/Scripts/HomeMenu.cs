using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject Credits;
    public GameObject Loading;

    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        Credits.SetActive(false);
        Instructions.SetActive(false);

        Loading.SetActive(false);
        musicSource.loop = true;

    }

    public void AudioToggle()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void PlayGame()
    {
        Loading.SetActive(true);
        SceneManager.LoadSceneAsync(1);

    }

    public void ToggleInstructions()
    {
        if (Instructions.activeSelf)
        {
            Instructions.SetActive(false);
            Credits.SetActive(false);
        }
        else
        {
            Instructions.SetActive(true);
            Credits.SetActive(false);
        }

    }

    public void ToggleCredits()
    {
        if (Credits.activeSelf)
        {
            Credits.SetActive(false);
            Instructions.SetActive(false);
        }
        else
        {
            Credits.SetActive(true);
            Instructions.SetActive(false);
        }
    }

}
