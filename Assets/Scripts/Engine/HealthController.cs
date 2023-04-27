using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private CharacterStats characterStats;

    public int CurrentHealth { get; set; }

    void Start() {
        CurrentHealth = characterStats.Health;    
    }

    public void TakeDamage(int damage) {
        this.CurrentHealth -= damage;
    }

    public void Heal(int health) {
        this.CurrentHealth = Mathf.Min(CurrentHealth + health, characterStats.Health);
    }
}
