using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAutoSelector : UserConfirmGridSpaceSelector
{
    public GridAutoSelector(ISelectableIngester ingester, GridFilter gridFilter) : base(ingester, gridFilter)
    {

    }

    public override void GatherSelections()
    {
        base.GatherSelections();

        // TODO: Maybe make this more efficient
        foreach(GridSpaceSelectable selectable in GetSelectableSpaces()) {
            base.Select(selectable);
        }
    }

    public override void Deselect()
    {
        
    }

    public override void Select(GridSpaceSelectable gridSpaceSelectable)
    {
        
    }

    public override bool SelectionFinished()
    {
        return true;
    }
}
