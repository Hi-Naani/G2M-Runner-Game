using System;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    public Player_Movement playerMovement;
    public GameObject text, gameOverPanel;

    public Text goldScore, silverScore, bronzeScore;
    public Text goldCountPicked, silverCountPicked, bronzeCountPicked;
    public Text goldCountMissed, silverCountMissed, bronzeCountMissed;

    private void Awake()
    {
        text.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void UpdateGoldCount()
    {
        //goldScore.text = Convert.ToString(playerMovement.goldCollections);
        goldScore.text = playerMovement.goldCollections.ToString();
    }

    public void UpdateSilverCount()
    {
        silverScore.text = Convert.ToString(playerMovement.silverCollections);
    }

    public void UpdateBronzeCount()
    {
        bronzeScore.text = Convert.ToString(playerMovement.bronzeCollections);
    }

    public void FinalScores()
    {
        goldCountPicked.text = playerMovement.goldCollections.ToString();
        silverCountPicked.text = Convert.ToString(playerMovement.silverCollections);
        bronzeCountPicked.text = Convert.ToString(playerMovement.bronzeCollections);
    }

    public void CoinsMissedCount()
    {
        goldCountMissed.text = playerMovement.goldMissed.ToString();
        silverCountMissed.text = playerMovement.silverMissed.ToString();
        bronzeCountMissed.text = playerMovement.bronzeMissed.ToString();
    }

}
