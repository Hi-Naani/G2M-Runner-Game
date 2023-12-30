using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Practice_2_RayCast : MonoBehaviour
{
    public float distance;
    //public LayerMask layer;
    //public int layer1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.position = this.transform.position + transform.forward * speed* Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = this.transform.position + Vector3.forward * speed * Time.deltaTime;
        }
    }*/

    [ContextMenu("RayCast")]
    public void RayCast()
    {
        // Physics.Raycast
       /* RaycastHit hitinfo;
        if(Physics.Raycast(transform.position, transform.forward, out hitinfo, distance)) 
        {
            //Debug.Log(hitinfo.ToString());
            Debug.Log(hitinfo.collider.gameObject.name);
            //Debug.Log(hitinfo.collider.gameObject);
            //Debug.Log(hitinfo.collider.gameObject.transform.position);
            //Debug.Log(hitinfo.collider.gameObject);

        }*/

        // Physics.RayCastAll
        RaycastHit[] hitinfo = Physics.RaycastAll(transform.position, Vector3.forward, Mathf.Infinity);

        for(int i = 0; i < hitinfo.Length; i++)
        {
            //Debug.Log(hitinfo[i].collider.gameObject.name);
             //hitinfo[i].collider.gameObject.GetComponent<Obstacle>().ReduceHealth();

            // through ** SendMessage ** Method we are call the another method other argument that we can pass is ** Object value ** it is the parameter of the method that we are calling

            hitinfo[i].collider.gameObject.SendMessage("ReduceHealth", 5);
        }
    }

    public void ReduceHealth()
    {
        Debug.Log("Reduce Health");
    }
}
