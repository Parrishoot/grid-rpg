using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUIController : MonoBehaviour
{
    public CharacterStats characterStats;

    public CharacterManager characterManager;

    public TMP_Text healthText;
    public TMP_Text speedText;
    public TMP_Text staminaText;
    public TMP_Text prowessText;
    public TMP_Text powerText;
    public TMP_Text intelligenceText;

    void Update() {
        healthText.text = characterManager.HealthController.CurrentHealth.ToString() + " / " + characterStats.Health;
        speedText.text = characterStats.Speed.ToString();
        staminaText.text = characterManager.StaminaController.CurrentStamina.ToString() + " / " + characterStats.Stamina;
        prowessText.text = characterStats.Prowess.ToString();
        powerText.text = characterStats.Power.ToString();
        intelligenceText.text = characterStats.Intelligence.ToString();
    }

}
