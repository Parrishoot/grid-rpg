using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class GridSpaceSelector
{
    protected ISelectableIngester ingester;

    protected GridFilter gridFilter;

    public GridSpaceSelector(ISelectableIngester ingester, GridFilter gridFilter) {
        this.ingester = ingester;
        this.gridFilter = gridFilter;
    }

    public abstract void GatherSelections();

    public virtual void ProcessSelections(List<GridSpaceSelectable> selections) {
        ingester.ProcessSelections(selections);
    }

    public virtual List<GridSpaceSelectable> GetSelectableSpaces() {
        return SelectionManager.GetInstance().GetSelectables().ToList().FindAll(x => gridFilter.Evaluate(x));
    }
}
