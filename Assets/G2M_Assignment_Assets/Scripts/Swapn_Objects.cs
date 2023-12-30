using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapn_Objects : MonoBehaviour
{
    public GameObject player;
    public Player_Movement playerMovement;

    public int[] numbers;

    public GameObject goldCoin;
    GameObject goldCoinSearch;
    [HideInInspector]public bool goldCoinSwapned = false;


    public GameObject silverCoin;

    public GameObject bronzeCoin;

    [HideInInspector] public bool instantiatedGold = false;
    [HideInInspector] public bool instantiatedSilver = false;
    [HideInInspector] public bool instantiatedBronze = false;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (goldCoinSwapned == false)
        {
            
            if (player.transform.position.z > -10 && GameObject.FindGameObjectWithTag("Gold Coin") == null)
            {
                Invoke("InstantiateGoldCoin", 0.5f);
                instantiatedGold = true;

                goldCoinSwapned = true;

                playerMovement.selfDestroyGoldCoin = false;
            }
        }

        if(playerMovement.goldCoinDestroyed == true) 
        {
            
            playerMovement.goldCoinDestroyed = false;
            if (GameObject.FindGameObjectWithTag("Silver Coin") == null)
            {
                Invoke("InstantiateSilverCoin", 0.5f);
                instantiatedSilver = true;

                playerMovement.selfDestroySilverCoin = false;

            }
           
        }

        if (playerMovement.silverCoinDestroyed == true)
        {
            
            playerMovement.silverCoinDestroyed = false;
            if (GameObject.FindGameObjectWithTag("Bronze Coin") == null)
            {
                Invoke("InstantiateBronzeCoin", 0.5f);
                instantiatedBronze = true;

                playerMovement.selfDestroyBronzeCoin = false;

            }
            
        }

    }

    void InstantiateGoldCoin()
    {
        //int[] numbers = { -2, 0, 2 };
        int randomNumber_gold = numbers[Random.Range(0, numbers.Length)];
        //Debug.Log(randomNumber_gold);
        Instantiate(goldCoin, new Vector3(randomNumber_gold, 0.5f, player.transform.position.z + 5)/*player.transform.position + new Vector3(randomNumber, 0.5f, 5)*/, goldCoin.transform.rotation);
    }

    void InstantiateSilverCoin()
    {
        int randomNumber_Silver = numbers[Random.Range(0, numbers.Length)];
        Instantiate(silverCoin, new Vector3(randomNumber_Silver, 0.35f, player.transform.position.z + 5), silverCoin.transform.rotation);
    }

    void InstantiateBronzeCoin()
    {
        int randomNumber_Bronze = numbers[Random.Range(0, numbers.Length)];
        //Debug.Log(randomNumber_Bronze);
        Instantiate(bronzeCoin, new Vector3(randomNumber_Bronze, 0.5f, player.transform.position.z + 5), bronzeCoin.transform.rotation);
    }
}
