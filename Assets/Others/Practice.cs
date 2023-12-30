using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Practice : MonoBehaviour
{
    //public Transform sphere;

    Vector3 startPosition;
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.position = startPosition + Vector3.up * Mathf.Sin(Time.time); 
    }

}

