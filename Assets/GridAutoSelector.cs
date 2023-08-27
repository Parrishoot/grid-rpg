using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAutoSelector : UserConfirmGridSpaceSelector
{
    public GridAutoSelector(SelectableIngester ingester, GridFilter gridFilter, PlayerSelectionController playerSelectionController) : base(ingester, gridFilter, playerSelectionController)
    {

    }

    public override void GatherSelections()
    {
        // TODO: Maybe make this more efficient
        foreach(GridSpaceSelectable selectable in GetSelectableSpaces()) {
            base.Select(selectable);
        }
    }

    public override void Deselect()
    {
        playerSelectionController.EndListening();
    }

    public override void Select(GridSpaceSelectable gridSpaceSelectable)
    {
        
    }

    public override bool SelectionFinished()
    {
        return true;
    }
}
