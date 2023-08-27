using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class GridSpaceSelector
{
    protected SelectableIngester ingester;

    protected GridFilter gridFilter;

    protected int numSelections;

    protected bool exact;

    public GridSpaceSelector(SelectableIngester ingester, GridFilter gridFilter, int numSelections = 1, bool exact = true) {
        this.ingester = ingester;
        this.gridFilter = gridFilter;
        this.numSelections = numSelections;
        this.exact = exact;
    }

    public abstract void GatherSelections();

    public virtual void ProcessSelections() {
        ingester.ProcessSelections();
    }

    public virtual List<GridSpaceSelectable> GetSelectableSpaces(List<GridSpaceSelectable> selections = null) {
        return GridManager.GetInstance()
                          .GetSpacesSelectables()
                          .FindAll(x => gridFilter.Evaluate(x));
    }

    public SelectableIngester GetIngester() {
        return ingester;
    }
}
