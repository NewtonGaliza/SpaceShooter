using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public void Show()
    {
        this.gameObject.SetActive(true);

        this.scoreText.text = (ScoreController.Score + " X");

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
