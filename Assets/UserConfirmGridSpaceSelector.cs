using System.Collections.Generic;
using System.Linq;

public abstract class UserConfirmGridSpaceSelector : GridSpaceSelector
{

    protected Stack<GridSpaceSelectable> selections = new Stack<GridSpaceSelectable>();

    protected PlayerSelectionController playerSelectionController;

    public UserConfirmGridSpaceSelector(ISelectableIngester ingester, GridFilter gridFilter, PlayerSelectionController playerSelectionController) : base(ingester, gridFilter)
    {
        this.playerSelectionController = playerSelectionController;
    }

    protected void DeselectAll() {
        while(selections.Count > 0) {
            selections.Pop().Deselect();
        }
    }
    
    public void ProcessSelections() {
        base.ProcessSelections(selections.ToList());
        DeselectAll();
        Cancel();
    }

    public override void GatherSelections() {
        playerSelectionController.AssignListener(this);
    }

    public virtual void ResetSelectableStatus(GridSpaceSelectable gridSpaceSelectable) {
        gridSpaceSelectable.SetSelectable(gridFilter.Evaluate(gridSpaceSelectable));
    }

    public virtual void SetEnabledSelectables() {

        List<GridSpaceSelectable> selectableSpaces = GetSelectableSpaces();

        foreach(GridSpaceSelectable gridSpaceSelectable in GridManager.GetInstance().GetSpacesSelectables()) {
            ResetSelectableStatus(gridSpaceSelectable);
        }
    }

    public void Cancel() {
        foreach(GridSpaceSelectable gridSpaceSelectable in GridManager.GetInstance().GetSpacesSelectables()) {
            gridSpaceSelectable.SetSelectable(false);
        }
        playerSelectionController.Listener = null;
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
