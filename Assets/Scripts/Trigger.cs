using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
   // public GameObject lig;
    bool fl = true;

   // string curTag = "none";
    public GameObject target;
    Collider ob = null;

    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;



        // if (curTag == "glass")
        // {
        if (ob)
        {
            fl = ob.gameObject.GetComponent<Drag>().get_fl();

            if (!fl)
            {
                ob.transform.position = Vector3.MoveTowards(ob.transform.position, target.transform.position, step);
                //ob.transform.rotation = target.transform.rotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
        // if (curTag == "metal")
        //{
        //    ob.transform.position = Vector3.MoveTowards(ob.transform.position, target[1].transform.position, step);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //lig.SetActive(true);

       // if (!fl)
       // {
          //  curTag = transform.parent.tag;
            ob = other;
       // }
    }

    private void OnTriggerExit(Collider other)
    {
        //lig.SetActive(false);
    }
}
