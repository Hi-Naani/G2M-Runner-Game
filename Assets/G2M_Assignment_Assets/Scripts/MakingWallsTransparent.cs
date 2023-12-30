using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingWallsTransparent : MonoBehaviour
{
    [SerializeField] GameObject player;
    GameObject[] Lwalls;
    Material colour;
    
    void Start()
    {
        Lwalls = GameObject.FindGameObjectsWithTag("Wall");
    }


    void Update()
    {
        

       for(int i = 0; i < Lwalls.Length; i++)
       {
            if (Lwalls[i].transform.position.z - player.transform.position.z <= 6)
            {

            }
       }
    }

   /* IEnumerator Transparent()
    {

    }*/
}
