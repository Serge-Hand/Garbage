using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using DG.Tweening;

public class Trig : MonoBehaviour
{
    public GameObject lig;
    public GameObject timer;


    // Start is called before the first frame update
    void Start()
    {
        //lig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    Time.timeScale = 1;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        // lig.SetActive(true);
        if (gameObject.tag == other.tag)
        {
            Destroy(other.gameObject);
            DOTween.KillAll();
            AudioManager.instance.Play("Accept");
            Vibration.Vibrate(500);
            ScoreManager.scoreVal += 10;
            timer.GetComponent<TimerScript>().plusTime();
        }
        else
        {
            Destroy(other.gameObject);
            AudioManager.instance.Play("Decline");
        }

        //Debug.Log(other.tag);
        //Debug.Log(gameObject.tag);

        //Destroy(other.gameObject);
    }
}
