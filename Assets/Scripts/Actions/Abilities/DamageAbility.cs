using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageAbility", menuName = "ScriptableObjects/Abilities/Damage Ability", order = 1)]
public class DamageAbility : Ability
{
    public int power;

    public int range;

    public int numTargets;

    public override string GetDescription()
    {
        string enemyText = numTargets >= 1 ? "Enemies" : "Enemy";
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Damage {1} {2} For {3} Damage Up To {4} {5} Away", numTargets, enemyText, power, range, rangeText);
    }

    public override GridFilter GetGridFilter(Vector2Int origin)
    {
        GridFilter gridFilter = new GridFilter();
        gridFilter.AddFilter(new RangeFilter(origin, range));
        gridFilter.AddFilter(new OccupantFilter<EnemySelectable>());

        return gridFilter;
    }
}
