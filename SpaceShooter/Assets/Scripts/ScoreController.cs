using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreController
{
    private static int score;

    public static int Score
    {
        get { return score; }

        set {
                score = value;
                if(score < 0)
                {
                    score = 0;
                }

                if(score > BestScore)
                {
                    BestScore = score;
                }
            }
    }

    public static int BestScore
    {
        get {
                int bestScore = PlayerPrefs.GetInt("bestScore", 0);
                return bestScore;
            }
        
        set {
                if(value > BestScore)
                {
                    PlayerPrefs.SetInt("bestScore", value);
                }
            }
    }
}
