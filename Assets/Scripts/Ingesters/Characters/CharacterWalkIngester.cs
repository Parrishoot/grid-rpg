using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkIngester : ISelectableIngester
{
    protected GridMover gridMover;

    public CharacterWalkIngester(GridMover gridMover) {
        this.gridMover = gridMover;
    }

    public void ProcessSelections(List<GridSpaceSelectable> selections)
    {
        gridMover.SetPath(selections[0].GetPath(), OnDestinationReached);
        SelectionManager.GetInstance().EndListening(true);
    }

    protected virtual void OnDestinationReached() {
        
    }
}
