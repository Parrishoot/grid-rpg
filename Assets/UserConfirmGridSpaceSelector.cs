using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class UserConfirmGridSpaceSelector : GridSpaceSelector
{

    protected Stack<GridSpaceSelectable> selections = new Stack<GridSpaceSelectable>();

    public UserConfirmGridSpaceSelector(ISelectableIngester ingester, GridFilter gridFilter) : base(ingester, gridFilter)
    {
    }

    protected void DeselectAll() {
        while(selections.Count > 0) {
            selections.Pop().Deselect();
        }
    }

    
    public void ProcessSelections() {
        base.ProcessSelections(selections.ToList());
        DeselectAll();
    }

    public override void GatherSelections() {
        SelectionManager.GetInstance().AssignListener(this);
    }

    public virtual void ResetSelectableStatus(GridSpaceSelectable gridSpaceSelectable) {
        gridSpaceSelectable.SetSelectable(gridFilter.Evaluate(gridSpaceSelectable));
    }

    public virtual void SetEnabledSelectables() {

        List<GridSpaceSelectable> selectableSpaces = GetSelectableSpaces();

        foreach(GridSpaceSelectable gridSpaceSelectable in SelectionManager.GetInstance().GetSelectables()) {
            ResetSelectableStatus(gridSpaceSelectable);
        }
    }

    public abstract bool SelectionFinished();

    public abstract void Deselect();

    public virtual void Select(GridSpaceSelectable gridSpace) {
        if(!gridSpace.Selected) {
            gridSpace.Select();
            selections.Push(gridSpace);
        }
    }
}
