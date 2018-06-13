using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    private int maxHearts = 2, healthPerHeart = 1;
    public int startHearts = 3;
    public static int currentHealth;
    public Image[] healthImages;
    public Sprite[] healthSprites;

    void Start()
    {
        currentHealth = startHearts * healthPerHeart;
        checkHealthAmount();
    }

    //checks current amount of player health
    public void checkHealthAmount()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    //updates player health bar to current to display the current amount of health each head is 1 health point, player starts with 3 health
    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;
        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if (currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageindex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageindex];
                    empty = true;
                }
            }
        }
    }

    void Update()
    {
        if (playerCollision.updateHealth == true)
        {
            playerCollision.updateHealth = false;
            UpdateHearts();
        }
    }

    //lowers health when they take damage
    public void takeDamage(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }
}