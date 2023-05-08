using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    [SerializeField]
    private CharacterStats characterStats;

    public int CurrentStamina { get; set; }

    void Start() {
        CurrentStamina = characterStats.Stamina;    
    }

    public void UseStamina(int stamina) {
        this.CurrentStamina -= stamina;
    }

    public void Replenish(int stamina) {
        this.CurrentStamina = Mathf.Min(CurrentStamina + stamina, characterStats.Stamina);
    }

    public bool StaminaAvailable(int stamina) {
        return this.CurrentStamina >= stamina;
    }
}
