using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class UserConfirmGridSpaceSelector : GridSpaceSelector
{

    protected PlayerSelectionController playerSelectionController;

    public UserConfirmGridSpaceSelector(SelectableIngester ingester, GridFilter gridFilter, PlayerSelectionController playerSelectionController, int numTargets = 1, bool exact = true) : base(ingester, gridFilter, numTargets, exact)
    {
        this.playerSelectionController = playerSelectionController;
    }

    protected void DeselectAll() {
        while(ingester.GetSelections().Count > 0) {
            ingester.RemoveSelection();
        }
    }
    
    public override void ProcessSelections() {
        base.ProcessSelections();
        DeselectAll();
        Cancel();
    }

    public override void GatherSelections() {
        playerSelectionController.AssignListener(this);
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
            ingester.AddSelection(gridSpace);

        }
    }
}
