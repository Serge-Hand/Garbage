using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UIElements;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UIManager : MonoBehaviour
{
    public static bool GameIsPaused = true;

    public GameObject darkPanel;
    public RectTransform menuPanel;
    public RectTransform menu;
    public RectTransform market;
    public GameObject timer;
    public RectTransform gameOverPanel;

    public GameObject money;
    public GameObject elements;

    public GameObject Ad;

    public RectTransform[] tutorial = new RectTransform[2];
    //public static GameObject score;

    private void Start()
    {
        //gameOverPanel.DOScale(new Vector3(0, 0, 0), 0.1f);
        //gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Pause()
    {
        GameManager.curSwipe = "block";
        darkPanel.SetActive(true);
        GameIsPaused = true;
        menuPanel.DOAnchorPosX(0, 0.25f);
        //Time.timeScale = 0f;
    }

    public void Resume()
    {
        GameManager.curSwipe = "none";
        darkPanel.SetActive(false);
        menuPanel.DOAnchorPosX(1530, 0.25f);
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        //Time.timeScale = 1f;
        //GameManager.kill();
        //GameIsPaused = false;
        menu.DOAnchorPosX(0, 0.25f);
        GameIsPaused = true;
        darkPanel.SetActive(false);
        timer.GetComponent<TimerScript>().clearTime();
        GameManager.kill();
        menuPanel.DOAnchorPosX(1530, 0.25f);
        ScoreManager.set_scoreVal();
        //SceneManager.UnloadSceneAsync("test");
        //SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        //menu.DOAnchorPosX(-1540, 0.25f);
        tutorial[1].DOAnchorPosX(-1540, 0.25f);
        //SceneManager.LoadScene("test");
        //DOTween.KillAll();
        GameManager.curSwipe = "block";
        GameManager.kill();
        GameIsPaused = false;
        GameManager.isWait = false;
        Data.SetTutorial();
    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.DOAnchorPosX(1530, 0.25f);
        //gameOverPanel.DOScale(new Vector3(0, 0, 0), 0.1f);
        //DOTween.KillAll();
        //gameOverPanel.SetActive(false);
        ScoreManager.set_scoreVal();
        //GameManager.kill();
        GameIsPaused = false;
        GameManager.kill();
        darkPanel.SetActive(false);
        timer.GetComponent<TimerScript>().clearTime();
        menuPanel.DOAnchorPosX(1530, 0.25f);
    }

    public void GameOverFun()
    {
        darkPanel.SetActive(true);
        //score.text = "" + ScoreManager.get_score();
        GameOverScript.set_scoreVal();
        //gameOverPanel.SetActive(true);
        gameOverPanel.DOAnchorPosX(0, 0.25f);
        //gameOverPanel.DOScale(new Vector3(4, 4, 0), 0.25f);
        //StartCoroutine(Jump());
        Debug.Log("Game Over");
        //ShowAd();
        GameManager.set_none();
        //GameIsPaused = true;
        Ad.GetComponent<Adcaller>().Adshower();
        GameManager.kill();
        //DOTween.KillAll();
        //GameIsPaused = true;
    }

    public void ShowAd()
    {
       // if (Advertisement.IsReady())
       // {
        //    Debug.Log("Show ad");
        //    Advertisement.Show();
       // }
    }

    public void OpenMarket()
    {
        UpdateMoney();
        market.DOAnchorPosX(0, 0.25f);
    }

    public void Back()
    {
        market.DOAnchorPosX(-1540, 0.25f);
    }

    public void Buy()
    {
        int result = GameManager.unlock();
        switch(result)
        {
            case 1:
                money.GetComponent<RectTransform>().DOShakeAnchorPos(0.5f, new Vector3(80, 0, 0), 10, 50, true);
                Vibration.Vibrate(500);
                AudioManager.instance.Play("Error");
                break;
            case 2:
                elements.GetComponent<RectTransform>().DOShakeAnchorPos(0.5f, new Vector3(80, 0, 0), 10, 50, true);
                Vibration.Vibrate(500);
                AudioManager.instance.Play("Error");
                break;
            case 0:
                UpdateMoney();
                AudioManager.instance.Play("Success");
                break;
        }
    }

    public void OpenTutorial()
    {
        if (Data.GetTutorial() == 0)
            menu.DOAnchorPosX(-1540, 0.25f);
        else
        {
            tutorial[0].gameObject.SetActive(false);
            tutorial[1].gameObject.SetActive(false);
            menu.DOAnchorPosX(-1540, 0.25f);
            Play();
        }
    }

    public void NextTutorial()
    {
        tutorial[0].DOAnchorPosX(-1640, 0.25f);
        tutorial[1].DOAnchorPosX(0, 0.25f);
    }

    void UpdateMoney()
    {
        Text moneyText = money.GetComponent<Text>();
        Text elementsText = elements.GetComponent<Text>();
        moneyText.text = "" + Data.GetMoney();
        elementsText.text = "" + GameManager.elements + "/80";
    }

    //IEnumerator Jump()
   // {
     //   Tween myTween;
        //Tween myTween = transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
        //myTween = gameOverPanel.DOAnchorPosX(0, 0.25f);
        //transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
     //   yield return myTween.WaitForKill();
        // This log will happen after the tween has completed
        //Debug.Log("Tween completed!");
    //}
}
