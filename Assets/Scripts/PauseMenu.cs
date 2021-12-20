using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject darkPanel;
    public GameObject menuPanel;

    public void Resume()
    {
        darkPanel.SetActive(false);

        /* Animator animator = menuPanel.GetComponent<Animator>();
         //bool isOpen = animator.GetBool("open");
         animator.SetBool("open", false);*/

        //LeanTween.moveX(menuPanel, 675, 2);

       // Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        darkPanel.SetActive(true);

        /* Animator animator = menuPanel.GetComponent<Animator>();
         //bool isOpen = animator.GetBool("open");
         animator.SetBool("open", true);*/

        //LeanTween.moveX(menuPanel, 100, 1);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
