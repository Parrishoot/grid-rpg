using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustableStatController : StatController
{
    private int currentValue;

    public AdjustableStatController(StatType statType, int value) : base(statType, value)
    {
        this.currentValue = value;
    }

    public override string GetStatText()
    {
        return string.Format("{0} / {1}", currentValue, base.GetStatText());
    }

    public void Lose(int adjustment) {
        currentValue -= adjustment;
    }

    public void Gain(int adjustment) {
        currentValue += adjustment;
    }
}
