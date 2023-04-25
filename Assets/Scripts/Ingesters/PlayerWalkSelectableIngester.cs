using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSelectableIngester : MonoBehaviour, ISelectableIngester
{
    public int range = 2;

    public GridMover gridMover;

    public void BeginListening() {
        GridSelectionListener listener = new SelectableListenerBuilder(this).WithRange(range)
                                                                            .WithOrigin(gridMover.currentGridPos)
                                                                            .Build();
        SelectionManager.GetInstance().AssignListener(listener);
    }

    public void ProcessSelections(List<GridSpaceSelectable> selections)
    {
        gridMover.SetGridTarget(selections[0].Space.CellCoords);
    }
}