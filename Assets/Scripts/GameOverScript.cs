using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public static int scoreVal = 0;
    public GameObject HighScoreObj;
    public GameObject moneyObj;
    static Text score;
    static Text HighScore;
    static Text money;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        HighScore = HighScoreObj.GetComponent<Text>();
        money = moneyObj.GetComponent<Text>();

    }

    public static void set_scoreVal()
    {
        score.text = "" + ScoreManager.get_score();
        Data.SaveData(ScoreManager.get_score(), ScoreManager.get_score() / 100 + 1);
        HighScore.text = "" + Data.GetScore();
        money.text = "" + (ScoreManager.get_score() / 100 + 1);
    }
}
