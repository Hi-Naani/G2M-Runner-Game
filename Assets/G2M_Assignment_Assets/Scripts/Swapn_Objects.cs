using UnityEngine;

public class Swapn_Objects : MonoBehaviour
{
    public GameObject player;
    public Player_Movement playerMovement;

    public int[] numbers;

    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject bronzeCoin;

    //GameObject goldCoinSearch;
    //[HideInInspector]public bool goldCoinSwapned = false;




    [HideInInspector] public bool instantiatedGold = false;
    [HideInInspector] public bool instantiatedSilver = false;
    [HideInInspector] public bool instantiatedBronze = false;

    #region // Swapning Coins Variables
    [HideInInspector] public bool hasGoldCoinToBeSwapned = true;
    [HideInInspector] public bool hasSilverCoinToBeSwapned = false;
    [HideInInspector] public bool hasBronzeCoinToBeSwapned = false;

    [HideInInspector] public bool goldCoinSwapned = false;
    [HideInInspector] public bool silverCoinSwapned = false;
    [HideInInspector] public bool bronzeCoinSwapned = false;
    #endregion


    void Start()
    {
        
    }

    
    void Update()
    {
       /* if (goldCoinSwapned == false)
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
            
        }*/

        if(player.transform.position.z > -10)
        {
            if(hasGoldCoinToBeSwapned)
            {
                Invoke("InstantiateGoldCoin", 0f);
                goldCoinSwapned = true;
            }

            if (hasSilverCoinToBeSwapned)
            {
                Invoke("InstantiateSilverCoin", 0f);
                silverCoinSwapned = true;
            }

            if (hasBronzeCoinToBeSwapned)
            {
                Invoke("InstantiateBronzeCoin", 0f);
                bronzeCoinSwapned = true;
            }
        }             

    }

    void InstantiateGoldCoin()
    {
        //int[] numbers = { -2, 0, 2 };
        int randomNumber_gold = numbers[Random.Range(0, numbers.Length)];
        Instantiate(goldCoin, new Vector3(randomNumber_gold, 0.5f, player.transform.position.z + 5)/*player.transform.position + new Vector3(randomNumber, 0.5f, 5)*/, goldCoin.transform.rotation);
        hasGoldCoinToBeSwapned = false;
    }

    void InstantiateSilverCoin()
    {
        int randomNumber_Silver = numbers[Random.Range(0, numbers.Length)];
        Instantiate(silverCoin, new Vector3(randomNumber_Silver, 0.35f, player.transform.position.z + 5), silverCoin.transform.rotation);
        hasSilverCoinToBeSwapned = false;
    }

    void InstantiateBronzeCoin()
    {
        int randomNumber_Bronze = numbers[Random.Range(0, numbers.Length)];
        Instantiate(bronzeCoin, new Vector3(randomNumber_Bronze, 0.5f, player.transform.position.z + 5), bronzeCoin.transform.rotation);
        hasBronzeCoinToBeSwapned = false;
    }
}
