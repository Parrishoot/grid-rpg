using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageAbility", menuName = "ScriptableObjects/Abilities/Damage Ability", order = 1)]
public class DamageAbility : UserInputAbility
{
    public int power;

    public int range;

    public override string GetDescription()
    {
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Damage An Enemy For {0} Damage Up To {1} {2} Away", power, range, rangeText);
    }

    protected override GridFilter GetFilter(CharacterManager characterManager)
    {
        GridFilter gridFilter = new GridFilter();
        gridFilter.AddFilter(new RangeFilter(characterManager.CharacterGridMover.CurrentGridPos, range));
        gridFilter.AddFilter(characterManager.SelectionController.GetEnemyOccupantFilter());

        return gridFilter;
    }

    protected override SelectableIngester GetIngester(CharacterManager characterManager)
    {
        SelectableIngester ingester = new CharacterAttackIngester(characterManager.CharacterStats.Power + power);
        return ingester;
    }
}
