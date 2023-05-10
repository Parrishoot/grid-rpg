using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

[CreateAssetMenu(fileName = "NewStatAugment", menuName = "ScriptableObjects/Augments/Stat Augment", order = 1)]
public class StatAdjustAbility : Ability
{
    public int adjustmentAmount;

    public StatType statType;

    public override void Apply(CharacterManager characterManager)
    {
        characterManager.CharacterStats.GetControllerForStat(statType).AdjustAugment(adjustmentAmount);
    }

    public override void Remove(CharacterManager characterManager)
    {
        characterManager.CharacterStats.GetControllerForStat(statType).AdjustAugment(-adjustmentAmount);
    }

    public override string GetDescription()
    {
        string prefix = adjustmentAmount >= 0 ? "Increase" : "Reduce";

        return string.Format("{0} {1} by {2}", prefix, statType.ToString(), adjustmentAmount);
    }
}
