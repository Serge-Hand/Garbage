using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;


public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    Rigidbody ob;
    private bool fl = true;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    string curSwipe;

    public float speed = 2.0f;
    GameObject[] target;

    private void Start()
    {
        Debug.Log("new");
        ob = GetComponent<Rigidbody>();
        //transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
        StartCoroutine(Jump());
        transform.DORotate(new Vector3(Random.Range(-100, 100), Random.Range(-360, 360), 0), 1.0f, RotateMode.FastBeyond360);

    }

    //private void OnMouseDown()
    //{
    //    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    //    mOffset = gameObject.transform.position - GetMouseWorldPos();
    //}
    //private void OnMouseUp()
    //{
    //    //ob.useGravity = true;
    //    fl = false;
    //}
    //private Vector3 GetMouseWorldPos()
    //{
    //    Vector3 mousePoint = Input.mousePosition;

    //    mousePoint.z = mZCoord;

    //    return Camera.main.ScreenToWorldPoint(mousePoint);
    //}
    //private void OnMouseDrag()
    //{
    //    if (fl)
    //        transform.position = GetMouseWorldPos() + mOffset;
    //    //ob.MovePosition(GetMouseWorldPos() + mOffset);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //ob.isKinematic = true;
    //}

    private void Update()
    {
        float step = speed * Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.R))
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //transform.Rotate(Vector3.left, speed);


        //Swipe();

        //if (curSwipe == "UP")
        //{
        //    ob.transform.position = Vector3.MoveTowards(ob.transform.position, target[0].transform.position, step);
        //}
        //if (curSwipe == "DOWN")
        //{
        //    ob.transform.position = Vector3.MoveTowards(ob.transform.position, target[1].transform.position, step);
        //}

    }

    public bool get_fl()
    {
        return fl;
    }

    IEnumerator Jump()
    {
        Tween myTween;
        //Tween myTween = transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
        myTween = transform.DOMove(new Vector3(0.1f, 0.6f, 0.0f), 0.75f);
        //transform.DOJump(new Vector3(0.1f, 0.6f, 0.0f), 1, 1, 1);
        yield return myTween.WaitForKill();
        // This log will happen after the tween has completed
        //Debug.Log("Tween completed!");
    }

    //public void Swipe()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //save began touch 2d point
    //        firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        //save ended touch 2d point
    //        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    //        //create vector from the two points
    //        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

    //        //normalize the 2d vector
    //        currentSwipe.Normalize();

    //        //swipe upwards
    //        if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
    //        {
    //            Debug.Log("up swipe");
    //            curSwipe = "UP";
    //        }
    //        //swipe down
    //        if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
    //        {
    //            Debug.Log("down swipe");
    //            curSwipe = "DOWN";
    //        }
    //        //swipe left
    //        if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
    //        {
    //            Debug.Log("left swipe");
    //            curSwipe = "LEFT";
    //        }
    //        //swipe right
    //        if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
    //        {
    //            Debug.Log("right swipe");
    //            curSwipe = "RIGHT";
    //        }
    //    }
    //}
}
