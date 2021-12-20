using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static void SaveData(int score, int coins)
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + coins);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public static int GetMoney()
    {
        return PlayerPrefs.GetInt("Money", 0);
    }

    public static void SetMoney(int money)
    {
        PlayerPrefs.SetInt("Money", money);
    }

    public static void DeleteMoney()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - 100);
    }

    public static void SaveElements(int elements)
    {
        PlayerPrefs.GetInt("Elements", 60);
        PlayerPrefs.SetInt("Elements", elements);
    }

    public static int GetElements()
    {
        return PlayerPrefs.GetInt("Elements", 60);
    }

    public static int GetTutorial()
    {
        return PlayerPrefs.GetInt("Tutorial", 0);
    }

    public static void SetTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
    }

}
