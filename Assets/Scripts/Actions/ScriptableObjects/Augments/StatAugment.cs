using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

[CreateAssetMenu(fileName = "NewStatAugment", menuName = "ScriptableObjects/Augments/Stat Augment", order = 1)]
public class StatAugment : Augment
{
    public int adjustmentAmount;

    public StatType statType;

    public override void Apply(CharacterManager characterManager)
    {
        Debug.Log("Augment!");
    }

    public override string GetDescription()
    {
        string prefix = adjustmentAmount >= 0 ? "Increase" : "Reduce";

        return string.Format("{0} {1} by {2}", prefix, statType.ToString(), adjustmentAmount);
    }
}
