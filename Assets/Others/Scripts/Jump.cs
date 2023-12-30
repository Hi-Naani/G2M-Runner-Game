using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody x;
    [SerializeField] float JumpHeight;
    bool ObjectGrounded, SpaceIsPressed;
    void Start()
    {
        x = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpaceIsPressed = true;
        }
        
    }

    void FixedUpdate()
    {
        if(SpaceIsPressed)
        {
            SpaceIsPressed = false; 
            Fly();
        }
        
    }

    private void Fly()
    {   
        if(ObjectGrounded)
        {
          x.AddForce(transform.up * JumpHeight, ForceMode.Impulse);       // vedant's code
         // x.AddForce(Vector3.up *  JumpHeight, ForceMode.Impulse);   // my code to test whether *Vector3* works in place of *transform* or not

        }
     }

    private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.transform.tag == "Grass")
        {
            Debug.Log("On Ground");
            ObjectGrounded = true;
        }
    }

     private void OnCollisionExit(Collision Collision)
    {
        if(Collision.transform.tag == "Grass")
        {
            Debug.Log("In Air");
            ObjectGrounded = false;
        }
    }
    
} 
