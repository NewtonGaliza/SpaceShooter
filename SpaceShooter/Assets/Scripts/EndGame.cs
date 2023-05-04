using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text txtBestScore;

    public void Show()
    {
        this.gameObject.SetActive(true);

        this.scoreText.text = (ScoreController.Score + " X");

        this.txtBestScore.text = ScoreController.BestScore.ToString();

        Time.timeScale = 0;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase01");
    }
}
