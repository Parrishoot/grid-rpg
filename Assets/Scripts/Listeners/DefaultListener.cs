using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultListener : GridSelectionListener
{
    public DefaultListener(ISelectableIngester ingester, int numTargets, bool exact, List<ISelectableFilter> filters)
     : base(ingester, numTargets, exact, filters)
    {
        
    }

    protected override void SetEnabledSelectables()
    {
        foreach(Selectable selectable in SelectionManager.GetInstance().GetSelectables()) {
            selectable.SetSelectable(true);
            selectable.StateController.SetIdle();
        }
    }

    public override void Select(GridSpaceSelectable gridSpace) {

        if(!(selections.Count == 0)) {
            GridSpaceSelectable existingSpace = selections.Pop();
            existingSpace.Deselect();
            existingSpace.StateController.SetIdle();
        }

        gridSpace.Select();
        selections.Push(gridSpace);
    }

    public override GridSpaceSelectable Deselect()
    {
        GridSpaceSelectable selectable = base.Deselect();
        selectable.StateController.SetIdle();

        return selectable;
    }

    public override bool SelectionFinished() {
        return false;
    }
}
