using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    public GameObject lig;

    // Start is called before the first frame update
    void Start()
    {
        //lig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        lig.SetActive(true);
    }
}
