using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIMenu : MonoBehaviour
{
    public AudioSource musicSource;
    public GameObject inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        inGameMenu.SetActive(false);
        musicSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ToggleMenu();
        }
    }
    public void AudioToggle()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync(0);
    }
    private void ToggleMenu()
    {
        if (inGameMenu.activeSelf)
        {
            inGameMenu.SetActive(false);
        }
        else
        {
            inGameMenu.SetActive(true);
        }
    }
}
