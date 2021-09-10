using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool start = false;
    [SerializeField] private GameObject startButton, pausePanel;
    public void StartButton()
    {
        startButton.SetActive(false);
        start = true;
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
