using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public LifeDisplay lifeDisplay;
    public GameManager gameManager;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            gameManager.PlayerDiedAnimation();
        } else {
            lifeDisplay.ChangeLife(health);
        }
    }

    public void GetHealth()
    {
        health = maxHealth;
        lifeDisplay.ChangeLife(health);
    }
}
