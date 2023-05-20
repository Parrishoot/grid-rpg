using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackIngester : ISelectableIngester
{
    private int power;

    public CharacterAttackIngester(int power) {
        this.power = power;
    }

    public void ProcessSelections(List<GridSpaceSelectable> selections)
    {
        foreach(GridSpaceSelectable selection in selections) {
            selection.Space.GetOccupantsParentTransform().GetComponentInChildren<CharacterStats>().GetHealthController().Lose(this.power);
        }
    }
}
