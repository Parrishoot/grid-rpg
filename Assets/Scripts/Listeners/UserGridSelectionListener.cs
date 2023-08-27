using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

public class UserGridSelectionListener: UserConfirmGridSpaceSelector {

    public UserGridSelectionListener(SelectableIngester ingester, GridFilter gridFilter, PlayerSelectionController playerSelectionController, int numTargets = 1, bool exact = true) : base(ingester, gridFilter, playerSelectionController, numTargets, exact) {

    }

    public override bool SelectionFinished() {

        if(ingester.GetSelections().Count == 0) {
            return false;
        }

        if(exact) {
            return ingester.GetSelections().Count == numSelections;
        }
        else {
            return ingester.GetSelections().Count <= numSelections;
        }
    }

    public override void GatherSelections() {
        base.GatherSelections();
        SetEnabledSelectables();
    }

    public void SetEnabledSelectables() {
        List<GridSpaceSelectable> selectableSpaces = GetSelectableSpaces();

        foreach(GridSpaceSelectable gridSpaceSelectable in selectableSpaces) {
            gridSpaceSelectable.SetSelectable(selectableSpaces.Contains(gridSpaceSelectable));
        }
    }

    public override void Select(GridSpaceSelectable gridSpace) {
        if(ingester.GetSelections().Count != numSelections) {
            base.Select(gridSpace);
        }
        else if(numSelections == 1) {
            GridSpaceSelectable previousGridSpace = ingester.RemoveSelection();
            previousGridSpace.Deselect();
            base.Select(gridSpace);
        }

        if(!SelectionFinished()) {
            SetEnabledSelectables();
        }
    }

    public override void Deselect() {
        if(ingester.GetSelections().Count != 0) {
            GridSpaceSelectable selectable = ingester.RemoveSelection();
            selectable.Deselect();
        }
        Cancel();
    }
}
