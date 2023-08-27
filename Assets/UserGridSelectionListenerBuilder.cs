using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGridSelectionListenerBuilder : UserGridSelectionListenerBuilderBase<UserGridSelectionListener>
{

    private PlayerSelectionController playerSelectionController;

    public UserGridSelectionListenerBuilder(SelectableIngester ingester, PlayerSelectionController playerSelectionController) : base(ingester)
    {
        this.playerSelectionController = playerSelectionController;
    }

    public override UserGridSelectionListener Build()
    {
        return new UserGridSelectionListener(ingester, gridFilter, playerSelectionController, numSelections, exact);
    }
}
