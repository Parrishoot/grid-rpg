using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAutoSelectorBuilder : GridSpaceSelectorBuilder<GridAutoSelector, GridAutoSelectorBuilder>
{

    PlayerSelectionController playerSelectionController;

    public GridAutoSelectorBuilder(SelectableIngester ingester, PlayerSelectionController playerSelectionController) : base(ingester)
    {
        this.playerSelectionController = playerSelectionController;
    }

    public override GridAutoSelector Build()
    {
        return new GridAutoSelector(ingester, gridFilter, playerSelectionController);
    }
}
