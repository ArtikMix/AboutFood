using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool start = false;
    [SerializeField] private GameObject startButton, pauseButton;
    [SerializeField] private Sprite pause, game;
    public void StartButton()
    {
        startButton.SetActive(false);
        start = true;
        pauseButton.SetActive(true);
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        //pausePanel.SetActive(true);
        pauseButton.GetComponent<Image>().sprite = pause;
    }

    public void ResumeButton()
    {
        //pausePanel.SetActive(false);
        Time.timeScale = 1f;
        pauseButton.GetComponent<Image>().sprite = game;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
