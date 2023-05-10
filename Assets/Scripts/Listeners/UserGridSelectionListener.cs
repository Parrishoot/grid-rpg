using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class UserGridSelectionListener: UserConfirmGridSpaceSelector {

    private int numTargets = 1;

    private bool exact = false;

    public UserGridSelectionListener(ISelectableIngester ingester, int numTargets, bool exact, GridFilter gridFilter): base(ingester, gridFilter) {
        this.numTargets = numTargets;
        this.exact = exact;
    }

    public override bool SelectionFinished() {

        if(selections.Count == 0) {
            return false;
        }

        if(exact) {
            return selections.Count == numTargets;
        }
        else {
            return selections.Count <= numTargets;
        }
    }

    public override void GatherSelections() {
        base.GatherSelections();
        SetEnabledSelectables();
    }

    public override void Select(GridSpaceSelectable gridSpace) {
        if(selections.Count != numTargets) {
            base.Select(gridSpace);
        }
        else if(numTargets == 1) {
            GridSpaceSelectable previousGridSpace = selections.Pop();
            previousGridSpace.Deselect();
            base.Select(gridSpace);
        }
    }

    public override void Deselect() {
        if(selections.Count != 0) {
            GridSpaceSelectable selectable = selections.Pop();
            selectable.Deselect();
        }
        else {
            SelectionManager.GetInstance().EndListening();
        }
    }
}
