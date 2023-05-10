using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultListener : GridSelectionListener
{
    public DefaultListener(ISelectableIngester ingester, int numTargets, bool exact, GridFilter gridFilter) : base(ingester, numTargets, exact, gridFilter)
    {
    }

    public override void GatherSelections()
    {
        DeselectSelections();
        base.GatherSelections();
    }

    public override void Select(GridSpaceSelectable gridSpace) {

        if(!(selections.Count == 0)) {
            GridSpaceSelectable existingSpace = selections.Pop();
            existingSpace.Deselect();
            existingSpace.SetStateControllersIdle();
        }

        gridSpace.Select();
        selections.Push(gridSpace);
    }

    public override GridSpaceSelectable Deselect()
    {
        GridSpaceSelectable selectable = base.Deselect();

        if(selectable != null) {
            selectable.SetStateControllersIdle();
        }

        return selectable;
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
