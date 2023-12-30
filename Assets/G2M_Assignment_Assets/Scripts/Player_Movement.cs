using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region //variables
    public Rigidbody rb;               // taking player's rigid body component reference 
    public float fspeed;              // forward speed
    public float jHeight;
    bool spacePressed = false;
    bool playerGrounded = false;

    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject bronzeCoin;

    float gPDistance;                   // Distance between goldcoin and player;
    float sPDistance;                   // Distance between silvercoin and player;
    float bPDistance;                   // Distance between bronzecoin and player;

    [HideInInspector] public bool selfDestroyGoldCoin;
    [HideInInspector] public bool selfDestroySilverCoin;
    [HideInInspector] public bool selfDestroyBronzeCoin;


    [HideInInspector] public bool goldCoinDestroyed = false;
    [HideInInspector] public bool silverCoinDestroyed = false;

    public Swapn_Objects swapnObjects;

    bool player_Destroyed = false;
    #endregion
    void Start()
    {
        
    }

    
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

        #region // destroying collectobles if player ,misses
        if (this.transform.position.z > -8)
        {
            
            if (swapnObjects.instantiatedGold == true && selfDestroyGoldCoin == false)
            {
                CheckDistanceandDestroy_Gold();
                
            }

            if (/*swapnObjects.instantiatedSilver == true && */selfDestroySilverCoin == false)
            {
                CheckDistanceandDestroy_Silver();
                
            }

            if (swapnObjects.instantiatedBronze == true && selfDestroyBronzeCoin == false)
            {
                CheckDistanceandDestroy_Bronze();
               // bronzeCoinDestroyed = true;
                
            }

        }
        #endregion

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
            Debug.Log("00");
            Destroy(this.gameObject);
            player_Destroyed = true;
        }

        if (collision.gameObject.tag == "Gold Coin")
        {
            Destroy(collision.gameObject);
            goldCoinDestroyed = true;
            selfDestroyGoldCoin = true;
        }

        if (collision.gameObject.tag == "Silver Coin")
        {
            Destroy(collision.gameObject);
            silverCoinDestroyed = true;
        }

        if (collision.gameObject.tag == "Bronze Coin")
        {
            Destroy(collision.gameObject);
            swapnObjects.goldCoinSwapned = false;
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

    void CheckDistanceandDestroy_Gold()
    {
        goldCoin = GameObject.FindGameObjectWithTag("Gold Coin");
        gPDistance = this.transform.position.z - goldCoin.transform.position.z;
        
        if (gPDistance > 6)
        {
            Destroy(goldCoin);
            goldCoinDestroyed = true;
            selfDestroyGoldCoin = true;
            swapnObjects.instantiatedGold = false;
        }
        
    }

    void CheckDistanceandDestroy_Silver()
    {
        if(swapnObjects.instantiatedSilver == true)
        {
            silverCoin = GameObject.FindGameObjectWithTag("Silver Coin");
            sPDistance = this.transform.position.z - silverCoin.transform.position.z;

            if (sPDistance > 6)
            {
                Destroy(silverCoin);
                silverCoinDestroyed = true;
                selfDestroySilverCoin = true;
                swapnObjects.instantiatedSilver = false;
            }
        }
        
    }

    void CheckDistanceandDestroy_Bronze()
    {
        bronzeCoin = GameObject.FindGameObjectWithTag("Bronze Coin");
        bPDistance = this.transform.position.z - bronzeCoin.transform.position.z;

        if (bPDistance > 6)
        {
            Destroy(bronzeCoin);
            selfDestroyBronzeCoin = true;
            swapnObjects.goldCoinSwapned = false;
            swapnObjects.instantiatedBronze = false;
        }
    }

 


}
