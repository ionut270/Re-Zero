using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    bool Hide = false;
    bool weapon = false;
    bool buttonHeal = false;
    bool buttonWeapon = false;

    public HealthBar healthBar;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDmg(20);
        }
    }

    void takeDmg(int damage) {
        currentHealth -= damage;
        if (currentHealth == 0) {
            gameManager.EndGame();
        }
        else
        { healthBar.setHealth(currentHealth);
        }
        
    }

    void heal(int heal) {
        currentHealth += heal;
        healthBar.setHealth(currentHealth);
    }

}
