using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public GameObject player;
    //private Vector3 camOffset = new Vector3 (0, 1.65f, -3.5f);
    
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        //transform.position = player.transform.position + camOffset;
        transform.position = new Vector3(this.transform.position.x, player.transform.position.y + 1.65f , player.transform.position.z - 3.5f);
    }
}
