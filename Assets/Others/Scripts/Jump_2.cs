using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_2 : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpHeight;
    bool onGround, spaceIsPressed;

    void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceIsPressed = true;
            Debug.Log("Space is Pressed");
           
        }
    }
    void FixedUpdate()
    {
        if (spaceIsPressed == true)
        {
            spaceIsPressed = false;
            Fly();
            
        }
    }

    void Fly()
    {
        if(onGround)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            
            
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Grass")
        {
             onGround = true;
            Debug.Log("OnGround");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Grass")
        {
            onGround = false;
            Debug.Log("InAir");
        }
    }
}
