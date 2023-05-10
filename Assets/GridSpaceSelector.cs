using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class GridSpaceSelector
{

    protected ISelectableIngester ingester;


    protected int numTargets = 1;

    protected bool exact = false;

    protected GridFilter gridFilter;

    public virtual void Init(ISelectableIngester ingester, int numTargets, bool exact, GridFilter gridFilter) {
        this.ingester = ingester;
        this.numTargets = numTargets;
        this.exact = exact;
        this.gridFilter = gridFilter;
    }

    public abstract void BeginProcessing();

    public virtual void ProcessSelections(List<GridSpaceSelectable> selections) {
        ingester.ProcessSelections(selections);
    }
}
