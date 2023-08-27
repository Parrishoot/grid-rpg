using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackIngester : SelectableIngester
{
    private int power;

    public CharacterAttackIngester(int power) {
        this.power = power;
    }

    public override void ProcessSelections()
    {
        while(selections.Count > 0) {
            GridSpaceSelectable selection = selections.Pop();
            selection.Space.GetOccupantsParentTransform().GetComponentInChildren<CharacterStats>().GetHealthController().Lose(this.power);
        }
    }
}
