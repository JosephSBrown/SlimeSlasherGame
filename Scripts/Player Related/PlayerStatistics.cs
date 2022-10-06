using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    public int currentHealth;
    private int MAX_HEALTH = 100;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Damage(7);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(100);
        }

    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("D Error");
        }
        this.currentHealth -= amount;
        if (currentHealth < 0)
        {
            die();
        }
        healthBar.setHealth(currentHealth);
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("H Error");
        }
        bool OverHealth = currentHealth + amount > MAX_HEALTH;
        if (OverHealth)
        {
            this.currentHealth = MAX_HEALTH;
        }
        else
        {
            this.currentHealth += amount;
        }
    }

    public void die()
    {
        Debug.Log("Dead");
        Destroy(gameObject);
    }

}
