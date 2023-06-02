using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkIngester : ISelectableIngester
{
    protected GridMover gridMover;

    protected CharacterTurnController characterTurnController;

    public CharacterWalkIngester(GridMover gridMover, CharacterTurnController characterTurnController) {
        this.gridMover = gridMover;
        this.characterTurnController = characterTurnController;
    }

    public override void ProcessSelections(List<GridSpaceSelectable> selections)
    {
        gridMover.SetPath(selections[0].GetPath(), ProcessPostIngestion);
    }
}
