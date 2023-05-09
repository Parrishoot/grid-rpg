using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUIController : MonoBehaviour
{
    public TMP_Text statNameText;

    public TMP_Text statValueText;

    private Color augmentedColor = Color.green;

    private StatController statController;

    public void Init(StatController statController) {
        this.statController = statController;
    }

    private void Update() {

        this.statNameText.SetText(statController.StatType.ToString());
        this.statValueText.SetText(statController.GetStatText());

        this.statValueText.color = this.statController.IsAugmented() ? augmentedColor : Color.white;
    }
}
