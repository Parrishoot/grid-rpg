using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class GridSelectionListener {

    protected Stack<GridSpaceSelectable> selections = new Stack<GridSpaceSelectable>();

    private ISelectableIngester ingester;

    private Vector2Int origin;

    private int numTargets = 1;

    private int range = 1;

    private bool exact = false;

    private List<ISelectableFilter> filters = new List<ISelectableFilter>();

    public GridSelectionListener() { }

    public GridSelectionListener(ISelectableIngester ingester, Vector2Int origin, int numTargets, int range, bool exact, List<ISelectableFilter> filters) {
        this.ingester = ingester;
        this.origin = origin;
        this.numTargets = numTargets;
        this.exact = exact;
        this.range = range;
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
            selectable.SetSelectable(InRange(selectable) && PassesFilters(selectable));
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

    private bool InRange(Selectable selectable) {
        int distance = selectable.Space.GetDistance(origin);
        return distance != 0 && distance <= range;
    }
}
