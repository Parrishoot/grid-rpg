using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelectionListenerBuilder : SelectableListenerBuilderBase<GridSelectionListener>
{
    public GridSelectionListenerBuilder(ISelectableIngester ingester) : base(ingester)
    {
    }

    public override GridSelectionListener Build()
    {
        return new GridSelectionListener(ingester, numTargets, exact, gridFilter);
    }
}
