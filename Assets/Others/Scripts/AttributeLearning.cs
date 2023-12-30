using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeLearning : MonoBehaviour
{
    [Header("Details of a player")]
    [SerializeField] private GameObject player;
    [Tooltip("Sorry for the inconvience")]
    [Range(1, 45)]
    public int playerAge;
    [Space(25)]

    public Vector3 playerPosition;

    [TextArea]
    public string aboutCapsule;
    [Multiline]
    public string aboutSphere;


  
    void Start()
    {
        
    }

  
    
}
