using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageAbility", menuName = "ScriptableObjects/Abilities/Walk Ability", order = 1)]
public class WalkAbility : UserInputAbility
{
    public int range;

    public int distanceWalked = 0;

    public override string GetDescription()
    {
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Walk Up To {0} {1} Away", range, rangeText);
    }

    protected override GridFilter GetFilter(CharacterManager characterManager)
    {
        GridFilter gridFilter = new GridFilter();
        gridFilter.AddFilter(new WalkableRangeFilter(characterManager.CharacterGridMover.CurrentGridPos, range, characterManager.CharacterGridMover.GetPathTracker()));

        return gridFilter;
    }

    protected override SelectableIngester GetIngester(CharacterManager characterManager)
    {
        return new CharacterWalkIngester(characterManager.CharacterGridMover, this, characterManager.CharacterTurnController);
    }

    public override void Reset()
    {
        base.Reset();

        distanceWalked = 0;
    }

    protected override int GetNumberOfTargets()
    {
        return int.MaxValue;
    }

    protected override bool GetExactSelection()
    {
        return false;
    }
}
