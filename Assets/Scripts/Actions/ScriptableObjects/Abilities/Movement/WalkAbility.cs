using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageAbility", menuName = "ScriptableObjects/Abilities/Walk Ability", order = 1)]
public class WalkAbility : Ability
{
    public int range;

    public override string GetDescription()
    {
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Walk Up To {0} {1} Away", range, rangeText);
    }

    public override GridFilter GetFilter(CharacterManager characterManager)
    {
        GridFilter gridFilter = new GridFilter();
        gridFilter.AddFilter(new WalkableRangeFilter(characterManager.CharacterGridMover.CurrentGridPos, range));
        gridFilter.AddFilter(new OccupantFilter<CharacterSelectable>(false));

        return gridFilter;
    }

    public override ISelectableIngester GetIngester(CharacterManager characterManager)
    {
        return new CharacterWalkIngester(range, characterManager.CharacterGridMover);
    }
}
