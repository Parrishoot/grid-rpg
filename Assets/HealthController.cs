using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int totalHealth;

    public int currentHealth;

    void Start() {
        currentHealth = totalHealth;    
    }

    public void TakeDamage(int damage) {
        this.currentHealth -= damage;
    }
}
