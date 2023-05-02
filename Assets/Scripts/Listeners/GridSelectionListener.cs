using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class GridSelectionListener {

    protected Stack<GridSpaceSelectable> selections = new Stack<GridSpaceSelectable>();

    private ISelectableIngester ingester;

    private int numTargets = 1;

    private bool exact = false;

    private GridFilter gridFilter;

    public GridSelectionListener() { }

    public GridSelectionListener(ISelectableIngester ingester, int numTargets, bool exact, GridFilter gridFilter) {
        this.ingester = ingester;
        this.numTargets = numTargets;
        this.exact = exact;
        this.gridFilter = gridFilter;
    }

    public virtual bool SelectionFinished() {

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

    public void ProcessSelections() {
        ingester.ProcessSelections(selections.ToList());
        DeselectSelections();
    }

    protected void DeselectSelections() {
        while(selections.Count > 0) {
            selections.Pop().Deselect();
        }
    }

    public virtual void BeginListening() {
        SetEnabledSelectables();
    }

    public virtual void Select(GridSpaceSelectable gridSpace) {
        if(selections.Count != numTargets) {
            selections.Push(gridSpace);
            gridSpace.Select();
        }
        else if(numTargets == 1) {
            GridSpaceSelectable previousGridSpace = selections.Pop();
            previousGridSpace.Deselect();
            selections.Push(gridSpace);
            gridSpace.Select();
        }
    }

    public virtual GridSpaceSelectable Deselect() {
        if(selections.Count != 0) {
            GridSpaceSelectable selectable = selections.Pop();
            selectable.Deselect();
            return selectable;
        }
        else {
            SelectionManager.GetInstance().EndListening();
            return null;
        }
    }

    public virtual void ResetSelectableStatus(GridSpaceSelectable gridSpaceSelectable) {
        gridSpaceSelectable.SetSelectable(this.gridFilter.Evaluate(gridSpaceSelectable));
    }

    protected virtual void SetEnabledSelectables() {
        foreach(GridSpaceSelectable gridSpaceSelectable in SelectionManager.GetInstance().GetSelectables()) {
            ResetSelectableStatus(gridSpaceSelectable);
        } 
    }
}
