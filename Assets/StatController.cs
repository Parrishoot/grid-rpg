using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatController
{

    public int Value { get; set; }

    public StatType StatType { get; set; }

    private int augment;

    public StatController(StatType statType, int value) {
        this.Value = value;
        this.StatType = statType;
        this.augment = 0;
    }

    public void AdjustAugment(int amount) {
        this.augment += amount;
    }

    public virtual String GetStatText() {
        return (this.Value + this.augment).ToString();
    }

    public bool IsAugmented() {
        return this.augment != 0;
    }
}
