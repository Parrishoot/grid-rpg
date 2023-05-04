using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageAbility", menuName = "ScriptableObjects/Abilities/Damage Ability", order = 1)]
public class DamageAbility : Ability
{
    public int power;

    public int range;

    public override string GetDescription()
    {
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Damage An Enemy For {0} Damage Up To {1} {2} Away", power, range, rangeText);
    }

    public override GridFilter GetFilter(CharacterManager characterManager)
    {
        GridFilter gridFilter = new GridFilter();
        gridFilter.AddFilter(new RangeFilter(characterManager.CharacterGridMover.CurrentGridPos, range));
        gridFilter.AddFilter(new OccupantFilter<EnemySelectable>());

        return gridFilter;
    }

    public override ISelectableIngester GetIngester(CharacterManager characterManager)
    {
        return new CharacterAttackIngester(characterManager.CharacterStats.Power + power);
    }
}
