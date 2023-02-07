using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Composer composer;
    public GameObject pauseUI;
    public KeyCode pauseButton;

    public void TogglePauseMenu()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        if (pauseUI.activeSelf)
        {
            composer.musicSource.Pause();
            Time.timeScale = 0f;
        }
        else
        {
            composer.musicSource.Play();
            Time.timeScale = 1f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            TogglePauseMenu();
        }
    }
}
