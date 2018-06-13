using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject deathScreen, winScreen, Player;
    public Image DeathImg, winImg;
    private float transition = 0.0f;

    //triggers the win screen or death scrren depending if the player has died or has won
    void Update()
    {
        DeadScreen();
        WinScreen();

    }

    public void DeadScreen()
    {
        if (HealthUi.currentHealth <= 0)
        {
            Player.GetComponent<PlayerMovment>().enabled = false;
            transition += Time.deltaTime;
            DeathImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
            deathScreen.SetActive(true);
        }
    }

    public void WinScreen()
    {
        if (spellingStory.win == true)
        {
            transition += Time.deltaTime;
            winImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
            winScreen.SetActive(true);
        }

    }
}