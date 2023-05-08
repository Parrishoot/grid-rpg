using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
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

    private Dictionary<StatType, StatController> statControllers;

    void Start() {
        statControllers = new Dictionary<StatType, StatController>();
        statControllers.Add(StatType.HEALTH, new StatController(StatType.HEALTH, Health));
        statControllers.Add(StatType.SPEED, new StatController(StatType.SPEED, Speed));
        statControllers.Add(StatType.STAMINA, new StatController(StatType.STAMINA, Stamina));
        statControllers.Add(StatType.PROWESS, new StatController(StatType.PROWESS, Prowess));
        statControllers.Add(StatType.POWER, new StatController(StatType.POWER, Power));
        statControllers.Add(StatType.INTELLIGENCE, new StatController(StatType.INTELLIGENCE, Intelligence));
    }

    public StatController GetControllerForStat(StatType statType) {
        return statControllers[statType];
    }
}
