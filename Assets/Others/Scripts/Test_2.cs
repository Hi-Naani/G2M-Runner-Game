using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_2 : MonoBehaviour
{
    private Camera container;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name} trigger with {other.gameObject.name}");
    }

}
