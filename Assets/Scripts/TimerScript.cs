using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    Image timerBar;
    public GameObject GameOver;
    public float maxTime = 5f;
    float timeLeft;

    bool isPlus = false;
    double tmp = 0;

    public GameObject ui;

    bool fl = true;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        Time.timeScale = 1;
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.GameIsPaused)
        {
            if (timeLeft > 0)
            {
                if (!isPlus)
                {
                    timeLeft -= Time.deltaTime;
                    timerBar.fillAmount = timeLeft / maxTime;
                }
                else
                {

                    if (tmp > 0 && timeLeft < maxTime)
                    {
                        timeLeft += Time.deltaTime;
                        tmp -= Time.deltaTime;
                        timerBar.fillAmount = timeLeft / maxTime;
                    }
                    else
                        isPlus = false;
                }
            }
            else
            {
                if (fl)
                {
                    //Time.timeScale = 0;
                    // GameOver.SetActive(true);
                    ui.GetComponent<UIManager>().GameOverFun();
                    fl = false;
                }
            }
        }
    }

    public void plusTime()
    {
        if (timeLeft < maxTime)
        {
            // for (double x = 0; x < 1.5f; x += Time.deltaTime)
            //{
            //timeLeft += 1.5f;
            isPlus = true;
            tmp = 1.1f;
            //   timerBar.fillAmount = timeLeft / maxTime;
            // }
        }

    }

    public void clearTime()
    {
        timeLeft = maxTime;
        fl = true;
    }
}
