using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_T : MonoBehaviour
{
    public int speed;
    public float limit_1 = 5.5f;
    public float limit_2 = 14.5f;

    [HideInInspector] public bool restrictInBlock_1 = true;
    [HideInInspector] public bool restrictInBlock_2 = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (restrictInBlock_1) 
        {
            if (this.transform.position.x <= -(limit_2)) // -14.5
            {
                this.transform.position = new Vector3(-(limit_2), this.transform.position.y, this.transform.position.z);
            }

            if (this.transform.position.x >= -(limit_1)) // -5.5
            {
                this.transform.position = new Vector3(-(limit_1), this.transform.position.y, this.transform.position.z);
            }
        }

        if (restrictInBlock_2)
        {
            if (this.transform.position.x >= (limit_2)) // 14.5
            {
                this.transform.position = new Vector3((limit_2), this.transform.position.y, this.transform.position.z);
            }

            if (this.transform.position.x <= (limit_1)) // 5.5
            {
                this.transform.position = new Vector3((limit_1), this.transform.position.y, this.transform.position.z);
            }
        }


        float _horizontalMovement = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.right * Time.deltaTime * speed * _horizontalMovement);
    }
}
