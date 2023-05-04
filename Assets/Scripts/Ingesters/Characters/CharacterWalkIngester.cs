using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkIngester : ISelectableIngester
{
    private GridMover gridMover;

    private int range;

    public CharacterWalkIngester(int range, GridMover gridMover) {
        this.range = range;
        this.gridMover = gridMover;
    }

    public void ProcessSelections(List<GridSpaceSelectable> selections)
    {
        gridMover.SetGridTarget(selections[0].Space.CellCoords);
        SelectionManager.GetInstance().EndListening();
    }
}
