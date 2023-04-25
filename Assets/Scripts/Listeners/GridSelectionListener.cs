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

    private List<ISelectableFilter> filters = new List<ISelectableFilter>();

    public GridSelectionListener() { }

    public GridSelectionListener(ISelectableIngester ingester, int numTargets, bool exact, List<ISelectableFilter> filters) {
        this.ingester = ingester;
        this.numTargets = numTargets;
        this.exact = exact;
        this.filters = filters;
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
    }

    public virtual void BeginListening() {
        SetEnabledSelectables();
    }

    public virtual void Select(GridSpaceSelectable gridSpace) {
        if(!SelectionFinished()) {
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

    protected virtual void SetEnabledSelectables() {
        foreach(Selectable selectable in SelectionManager.GetInstance().GetSelectables()) {
            selectable.SetSelectable(PassesFilters(selectable));
        } 
    }

    private bool PassesFilters(Selectable selectable) {
        
        bool pass = true;
        
        foreach(ISelectableFilter filter in filters) {
            pass = pass && filter.Filter(selectable);
            if(!pass) {
                return false;
            }
        }
        
        return true;
    }
}
