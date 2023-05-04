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
        selections[0].Space.GetOccupantsParentTransform().GetComponentInChildren<EnemySelectable>().healthController.TakeDamage(this.power);
        SelectionManager.GetInstance().EndListening();
    }
}
