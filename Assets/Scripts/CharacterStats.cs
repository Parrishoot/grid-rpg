using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public enum StatType {
        HEALTH,
        SPEED,
        STAMINA,
        PROWESS,
        POWER,
        INTELLIGENCE
    }

    // Self Explanatory
    [field: SerializeField]
    public int Health { get; set; }

    // Determines Turn Order
    [field: SerializeField]
    public int Speed { get; set; }

    // Determines Basic Movement Distance
    [field: SerializeField]
    public int Stamina { get; set; }

    // Determines Total Mana
    [field: SerializeField]
    public int Prowess { get; set; }

    // Determines Attack
    [field: SerializeField]
    public int Power { get; set; }

    // Determines Number of Moves
    [field: SerializeField]
    public int Intelligence { get; set; }
}
