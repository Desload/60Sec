using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score;

    public float ScoreUp { get => score; set => score += value; }

    public void Restart()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    public void TimeIsEnd()
    {
        gameEnd.SetActive(true);
        scoreText.text = "Score: " + score;
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
