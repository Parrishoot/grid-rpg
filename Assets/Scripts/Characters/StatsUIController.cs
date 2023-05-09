using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUIController : MonoBehaviour

{
    public GameObject statUIPrefab;

    public List<StatType> statOrder = new List<StatType>() {
        StatType.HEALTH,
        StatType.SPEED,
        StatType.STAMINA,
        StatType.PROWESS,
        StatType.POWER,
        StatType.INTELLIGENCE
    };

    public void Init(CharacterStats characterStats) {
        foreach(StatType stat in statOrder) {
            Instantiate(statUIPrefab, transform).GetComponent<StatUIController>().Init(characterStats.GetControllerForStat(stat));
        }
    }
}
