using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatController
{

    public int Value { get; set; }

    private StatType statType;

    private int augment;

    public StatController(StatType statType, int value) {
        this.Value = value;
        this.statType = statType;
        this.augment = 0;
    }

    public void AdjustAugment(int amount) {
        this.augment += amount;
    }
}
