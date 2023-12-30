using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] GameState myGameCurrentState;
    [SerializeField] Ammo ammoType;

    [ContextMenu("Show")]
    public void ShowCurrentState()
    {
        Debug.Log($"state : {(int)myGameCurrentState}, ammo : {(int)ammoType}");
        Debug.Log("Hi");
    }

    private void Start()
    {
       // Debug.Log("Hi");
    }
    public enum GameState
    {
        Loading,
        GamePlay,
        GameOver
    }

    public enum Ammo
    {
        Short,
        Medium,
        large
    }
}
