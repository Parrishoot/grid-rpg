using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAutoSelectorBuilder : GridSpaceSelectorBuilder<GridAutoSelector, GridAutoSelectorBuilder>
{
    public GridAutoSelectorBuilder(ISelectableIngester ingester) : base(ingester)
    {
    }

    public override GridAutoSelector Build()
    {
        return new GridAutoSelector(ingester, gridFilter);
    }
}
