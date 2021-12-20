using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
//using System;

public class GameManager : MonoBehaviour
{
    public GameObject[] trash;
    static GameObject curOb;

    static Vector2 firstPressPos;
    static Vector2 secondPressPos;
    Vector2 currentSwipe;

    public static string curSwipe = "none";

    public GameObject[] target;
    public float speed = 2.0f;

    public static float minSwipeLength = 150f;

    public static bool isWait = true;

    public static int elements = 0;
    public static int maxElements = 80;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.GetTutorial() == 0)
        {
            Data.SetMoney(500);
            Data.SaveElements(60);
        }
        //curOb = Instantiate(trash[0], new Vector3(-0.5f, 0.8f, 0.0f), Quaternion.identity);
        elements = Data.GetElements();
        curOb = Instantiate(trash[Random.Range(0, elements)], new Vector3(2.1f, 1.6f, 0.0f), Quaternion.identity);
        Debug.Log(target.Length);
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.GameIsPaused && !isWait)
        {
            float step = speed * Time.deltaTime;

            if (!curOb)
            {
                curSwipe = "none";
                if (Random.Range(0, 2) == 1)
                    curOb = Instantiate(trash[Random.Range(0, elements)], new Vector3(2.1f, 1.6f, 0.0f), Quaternion.identity);
                else
                    curOb = Instantiate(trash[Random.Range(0, elements)], new Vector3(-2.1f, 1.6f, 0.0f), Quaternion.identity);

                StartCoroutine(wait());
            }

            Swipe();
            if (curSwipe != "block")
            {
                if (curOb)
                {
                    if (curSwipe == "UP-RIGHT")
                    {
                        //Debug.Log("move up");
                        //curOb.transform.position = Vector3.MoveTowards(curOb.transform.position, target[0].transform.position, step);


                        //curOb.transform.DOBlendableMoveBy(target[0].transform.position, 20f);
                        curSwipe = "block";
                        playSound();
                        curOb.transform.DORotate(new Vector3(Random.Range(-100, 100), Random.Range(-360, 360), 0), 1.0f, RotateMode.FastBeyond360);
                        //curOb.transform.DOBlendableMoveBy(target[0].transform.position, 2f);
                        curOb.transform.DOMove(target[0].transform.position, 1.5f);
                        //StartCoroutine(Move(0));
                        //curSwipe = "none";
                    }
                    if (curSwipe == "DOWN-RIGHT")
                    {
                        //Debug.Log("move down");
                        //curOb.transform.position = Vector3.MoveTowards(curOb.transform.position, target[1].transform.position, step);
                        curSwipe = "block";
                        playSound();
                        curOb.transform.DORotate(new Vector3(Random.Range(-100, 100), Random.Range(-360, 360), 0), 1.0f, RotateMode.FastBeyond360);
                        //curOb.transform.DOBlendableMoveBy(target[1].transform.position, 2f);
                        curOb.transform.DOMove(target[1].transform.position, 1.5f);
                    }
                    if (curSwipe == "UP-LEFT")
                    {
                        //Debug.Log("move down");
                        //curOb.transform.position = Vector3.MoveTowards(curOb.transform.position, target[2].transform.position, step);
                        curSwipe = "block";
                        playSound();
                        curOb.transform.DORotate(new Vector3(Random.Range(-100, 100), Random.Range(-360, 360), 0), 1.0f, RotateMode.FastBeyond360);
                        //curOb.transform.DOBlendableMoveBy(target[2].transform.position, 2f);
                        curOb.transform.DOMove(target[2].transform.position, 1.5f);
                    }
                    if (curSwipe == "DOWN-LEFT")
                    {
                        //Debug.Log("move down");
                        //curOb.transform.position = Vector3.MoveTowards(curOb.transform.position, target[3].transform.position, step);
                        curSwipe = "block";
                        playSound();
                        curOb.transform.DORotate(new Vector3(Random.Range(-100, 100), Random.Range(-360, 360), 0), 1.0f, RotateMode.FastBeyond360);
                        //curOb.transform.DOBlendableMoveBy(target[3].transform.position, 2f);
                        curOb.transform.DOMove(target[3].transform.position, 1.5f);
                    }
                }

               /* if (Input.GetKeyDown(KeyCode.R))
                {
                    ScoreManager.scoreVal = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    Time.timeScale = 1;
                }*/
            }
        }
    }

    public void Swipe()
    {
        if (!UIManager.GameIsPaused)
        {
            if (curSwipe != "block")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //save began touch 2d point
                    firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    //save ended touch 2d point
                    secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                    //create vector from the two points
                    currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                    if (currentSwipe.magnitude < minSwipeLength)
                    {
                        curSwipe = "none";
                        return;
                    }

                    //normalize the 2d vector
                    currentSwipe.Normalize();

                    //swipe upwards
                    //if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    //{
                    //    Debug.Log("up swipe");
                    //    curSwipe = "UP";
                    //}
                    if (currentSwipe.y > 0 && currentSwipe.x > 0.25f && currentSwipe.x < 0.85f)
                    {
                        Debug.Log("up-right swipe");
                        curSwipe = "UP-RIGHT";
                    }
                    //swipe down
                    //if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    //{
                    //    Debug.Log("down swipe");
                    //    curSwipe = "DOWN";
                    //}
                    if (currentSwipe.y < 0 && currentSwipe.x > 0.25f && currentSwipe.x < 0.85f)
                    {
                        Debug.Log("down-right swipe");
                        curSwipe = "DOWN-RIGHT";
                    }
                    //swipe left
                    //if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    //{
                    //    Debug.Log("left swipe");
                    //    curSwipe = "LEFT";
                    //}
                    if (currentSwipe.y < 0 && currentSwipe.x < -0.25f && currentSwipe.x > -0.85f)
                    {
                        Debug.Log("down-left swipe");
                        curSwipe = "DOWN-LEFT";
                    }
                    //swipe right
                    //if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    //{
                    //    Debug.Log("right swipe");
                    //    curSwipe = "RIGHT";
                    //}
                    if (currentSwipe.y > 0 && currentSwipe.x < -0.25f && currentSwipe.x > -0.85f)
                    {
                        Debug.Log("up-left swipe");
                        curSwipe = "UP-LEFT";
                    }
                }
            }
        }
    }

    IEnumerator Move(int num)
    {
        Tween myTween;
        //curOb.transform.DORotate(new Vector3(Random.Range(-100, 100), Random.Range(-360, 360), 0), 1.0f, RotateMode.FastBeyond360);
        myTween = curOb.transform.DOBlendableMoveBy(target[num].transform.position, 1f);
        //Tween myTween = transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
        //myTween = transform.DOMove(new Vector3(0.1f, 0.6f, 0.0f), 0.75f);
        //transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
        yield return myTween.WaitForKill();
        // This log will happen after the tween has completed
        //Debug.Log("Tween completed!");
    }

    void playSound()
    {
        if (!UIManager.GameIsPaused)
        {
            switch (curOb.tag)
            {
                case "metal":
                    AudioManager.instance.Play("Metal");
                    break;
                case "glass":
                    AudioManager.instance.Play("Glass");
                    break;
                case "bio":
                    AudioManager.instance.Play("BIO");
                    break;
                case "plastic":
                    AudioManager.instance.Play("Plastic");
                    break;
                default:
                    break;
            }
        }
    }

    public static int unlock()
    {
        if (Data.GetMoney() < 100)
            return 1;
        if (elements == maxElements)
            return 2;
        elements++;
        Data.SaveElements(elements);
        Data.DeleteMoney();
        return 0;
    }

    public static void kill()
    {
        Destroy(curOb);
    }

    IEnumerator wait()
    {
        isWait = true;
        yield return new WaitForSeconds(0.4f);
        isWait = false;
    }

    public static void set_none()
    {
        secondPressPos.Set(firstPressPos.x, firstPressPos.y);
        //secondPressPos.Set(0, 0);
    }
}
