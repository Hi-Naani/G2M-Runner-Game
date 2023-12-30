using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporting_T : MonoBehaviour
{
    public GameObject ref_1;
    public GameObject ref_2;

    public PlayerMovement_T playerMovement;
    void Start()
    {
        
    }

    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            //StartCoroutine("Teleporting");
            StartCoroutine(Teleporting());

        } 
    }

    IEnumerator Teleporting()
    {
        
        yield return new WaitForSeconds(0.5f);

        if(playerMovement.restrictInBlock_1 == true)
        {
            
            playerMovement.restrictInBlock_1 = false;
           // yield return new WaitForSeconds(0.25f);
            this.transform.position = ref_1.transform.position;
            playerMovement.restrictInBlock_2 = true;
            yield break;

        }

        if (playerMovement.restrictInBlock_2 == true)
        {
            
            playerMovement.restrictInBlock_2 = false;
           // yield return new WaitForSeconds(0.25f);
            this.transform.position = ref_2.transform.position;   
            playerMovement.restrictInBlock_1 = true;
            yield break;

        }

    }
}
