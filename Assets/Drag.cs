using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    Rigidbody ob;

    private void Start()
    {
        ob = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        ob.useGravity = true;
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
        //ob.MovePosition(GetMouseWorldPos() + mOffset);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ob.isKinematic = true;
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.R))
               SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
