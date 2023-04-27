using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultListener : GridSelectionListener
{
    public DefaultListener(ISelectableIngester ingester, int numTargets, bool exact, List<ISelectableFilter> filters)
     : base(ingester, numTargets, exact, filters)
    {
        
    }

    public override void BeginListening()
    {
        DeselectSelections();
        base.BeginListening();
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
