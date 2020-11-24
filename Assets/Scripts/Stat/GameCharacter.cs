using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public string characterType;
    public float height = 2f;

    public int maxHealth = 100;
    public int currentHealth;

    public int damage;

    public event System.Action<int, int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            this.die();
        }
    }

    public virtual void die()
    {

    }
}
