using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultListener : UserGridSelectionListener
{
    public DefaultListener(ISelectableIngester ingester, int numTargets, bool exact, GridFilter gridFilter) : base(ingester, numTargets, exact, gridFilter)
    {
    }

    public override void GatherSelections()
    {
        DeselectAll();
        base.GatherSelections();
    }

    public override void Select(GridSpaceSelectable gridSpace) {

        if(!(selections.Count == 0)) {
            GridSpaceSelectable existingSpace = selections.Pop();
            existingSpace.Deselect();
            existingSpace.SetStateControllersIdle();
        }

        base.Select(gridSpace);
    }

    public override void Deselect()
    {

        GridSpaceSelectable selectable = selections.Peek();

        base.Deselect();

        if(selectable != null) {
            selectable.SetStateControllersIdle();
        }
    }

    public override void ResetSelectableStatus(GridSpaceSelectable gridSpaceSelectable)
    {
        base.ResetSelectableStatus(gridSpaceSelectable);
        
        if(!gridSpaceSelectable.Selected) {
            gridSpaceSelectable.SetStateControllersIdle();
        }
    }

    public override bool SelectionFinished() {
        return false;
    }
}
