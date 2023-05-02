using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private Lifebar lifeBar;
    private Player player;

    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textScore.text = (ScoreController.Score + " X");

        this.lifeBar.ShowLifes(this.player.Life);
    }
}
