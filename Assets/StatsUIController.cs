using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUIController : MonoBehaviour
{
    public CharacterStats characterStats;

    public HealthController healthController;

    public TMP_Text healthText;
    public TMP_Text speedText;
    public TMP_Text staminaText;
    public TMP_Text prowessText;
    public TMP_Text powerText;
    public TMP_Text intelligenceText;

    void Update() {
        healthText.text = healthController.CurrentHealth.ToString() + " / " + characterStats.Health;
        speedText.text = characterStats.Speed.ToString();
        staminaText.text = characterStats.Stamina.ToString();
        prowessText.text = characterStats.Prowess.ToString();
        powerText.text = characterStats.Power.ToString();
        intelligenceText.text = characterStats.Intelligence.ToString();
    }

}
