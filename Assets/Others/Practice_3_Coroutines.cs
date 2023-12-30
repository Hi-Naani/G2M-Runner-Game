using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_3_Coroutines : MonoBehaviour
{
    public GameObject obj;
    float time = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            
           obj = Instantiate(obj, transform.position, /*Quaternion.identity*/transform.rotation);

            obj.transform.Translate(Vector3.forward * Time.deltaTime * 10);

            time = 0;
        }
        

       /* if(obj.transform.position.z > 5)
        {
            Destroy(obj);
        }*/

    }

    public void PrintSomething() => Debug.Log("Hello World");

    public void Testing() => Debug.Log("HI");
}
