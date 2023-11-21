using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textScore;
    public Text lifeScore;
    public int score;
    public int life = 3;
    public GameObject gameOver;
    public GameObject pauseScreen;
    public AudioSource gameoverSound;

    public void SetScore(int val)
    {
        score += val;
        textScore.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        gameoverSound.Play();
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void LifeScore()
    {
        life--;
        lifeScore.text = life.ToString();

        if (life == 0)
        {
            GameOver();
        }
    }
}
