using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region //variables
    public Rigidbody rb;               // taking player's rigid body component reference 
    public float fspeed;               // forward speed
    public float jHeight;              // jump height length
    bool spacePressed = false;
    bool playerGrounded = false;
    public MeshRenderer player;

    // To store references
    GameObject goldCoin;             
    GameObject silverCoin;
    GameObject bronzeCoin;

    float gPDistance;                   // Distance between goldcoin and player;
    float sPDistance;                   // Distance between silvercoin and player;
    float bPDistance;                   // Distance between bronzecoin and player;

    public Swapn_Objects swapnObjects;  // A class
    public GameUI gameUI;

    bool player_Destroyed = false;       // To pause

    [HideInInspector] public int goldCollections = 0;
    [HideInInspector] public int silverCollections = 0;
    [HideInInspector] public int bronzeCollections = 0;

    [HideInInspector] public int goldMissed = 0;
    [HideInInspector] public int silverMissed = 0;
    [HideInInspector] public int bronzeMissed = 0;
    #endregion

    void Update()
    {
        if (player_Destroyed == true)
        {
            Time.timeScale = 0;
        }
        #region // Player's Sidewise Movement

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!(transform.position.x <= -2))
            {
                this.transform.position = transform.position - new Vector3(2, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!(transform.position.x >= 2))
            {
                this.transform.position = transform.position + new Vector3(2, 0, 0);
            }
        }
        #endregion

        #region//Space Input for Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
        #endregion
     

        StartCoroutine(Coins_SelfDestory());

    }



    void FixedUpdate()
    {
        #region   // Forward Movement
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(Vector3.forward * fspeed, ForceMode.Force);
            rb.transform.position = transform.position + new Vector3(0, 0, 1) * fspeed;
            //rb.transform.Translate(Vector3.forward * fspeed);
        }
        #endregion

        #region//Calling Fly Method
        if (spacePressed == true)
        {
            Fly();
            spacePressed = false;  
        }
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        #region//Destroying Coins and Player
        if (collision.gameObject.tag == "Wall")
        {
            //Destroy(this.gameObject);
            player.gameObject.GetComponent<Renderer>().enabled = false;
            player_Destroyed = true;
            gameUI.FinalScores();
            gameUI.CoinsMissedCount();
            gameUI.text.SetActive(false);
            gameUI.gameOverPanel.SetActive(true);
        } 
       

        if (collision.gameObject.tag == "Gold Coin")
        {
            Destroy(collision.gameObject);
            swapnObjects.hasSilverCoinToBeSwapned = true;
            goldCollections++;
            gameUI.UpdateGoldCount();
        }

        if (collision.gameObject.tag == "Silver Coin")
        {
            Destroy(collision.gameObject);
            swapnObjects.hasBronzeCoinToBeSwapned = true;
            silverCollections++;
            gameUI.UpdateSilverCount();
        }

        if (collision.gameObject.tag == "Bronze Coin")
        {
            Destroy(collision.gameObject);
            swapnObjects.hasGoldCoinToBeSwapned = true;
            bronzeCollections++;
            gameUI.UpdateBronzeCount();
        }
        #endregion

        // Checking whether Player is on Ground or not
        if (collision.gameObject.tag == "Lane")
        {
            playerGrounded = true;
        }
    }

    void Fly()
    {
        if(playerGrounded == true)
        {
            rb.AddForce(Vector3.up * jHeight, ForceMode.Impulse);
        }
        
    }

    
   

    IEnumerator Coins_SelfDestory()
    {
        if (swapnObjects.goldCoinSwapned)
        {
            yield return new WaitForSeconds(0.5f);
            goldCoin = GameObject.FindGameObjectWithTag("Gold Coin");

            if(goldCoin != null)
            {
                gPDistance = this.transform.position.z - goldCoin.transform.position.z;

                if (gPDistance > 6)
                {
                    Destroy(goldCoin);
                    swapnObjects.goldCoinSwapned = false;
                    swapnObjects.hasSilverCoinToBeSwapned = true;
                    goldMissed++;


                }
            }
            
        }

        if (swapnObjects.silverCoinSwapned)
        {
            yield return new WaitForSeconds(0.5f);
            silverCoin = GameObject.FindGameObjectWithTag("Silver Coin");

            if(silverCoin != null)
            {
                sPDistance = this.transform.position.z - silverCoin.transform.position.z;

                if (sPDistance > 6)
                {
                    Destroy(silverCoin);
                    swapnObjects.hasBronzeCoinToBeSwapned = true;
                    swapnObjects.silverCoinSwapned = false;
                    silverMissed++;
                }
            }
            
        }

        if (swapnObjects.bronzeCoinSwapned)
        {
            yield return new WaitForSeconds(0.5f);
            bronzeCoin = GameObject.FindGameObjectWithTag("Bronze Coin"); 

            if(bronzeCoin != null)
            {
                bPDistance = this.transform.position.z - bronzeCoin.transform.position.z;

                if (bPDistance > 6)
                {
                    Destroy(bronzeCoin);
                    swapnObjects.hasGoldCoinToBeSwapned = true;
                    swapnObjects.bronzeCoinSwapned = false;
                    bronzeMissed++;
                }
            }
            
        }
    }

    

}
