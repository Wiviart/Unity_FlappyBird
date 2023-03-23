using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool isPaused = true;
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject resumeButton;
    public GameObject deathMenu;
    private BirdController birdController;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
        deathMenu.SetActive(false);
        birdController = FindObjectOfType<BirdController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdController.isAlive) Terminal();
        else
        {
            if (isPaused) Resume();
            else Pause();
        }
    }
    public void Pause()
    {
        pauseButton.SetActive(false);
        playButton.SetActive(false);
        resumeButton.SetActive(true);
        Time.timeScale = 0f;
        isPaused = false;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        playButton.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
        isPaused = true;
    }
    public void Terminal()
    {
        deathMenu.SetActive(true);
        Pause();
        resumeButton.SetActive(false);
        FindObjectOfType<Score>().FinalScore();
    }
}
