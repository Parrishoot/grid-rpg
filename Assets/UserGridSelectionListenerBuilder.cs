using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGridSelectionListenerBuilder : UserGridSelectionListenerBuilderBase<UserGridSelectionListener>
{

    private PlayerSelectionController playerSelectionController;

    public UserGridSelectionListenerBuilder(ISelectableIngester ingester, PlayerSelectionController playerSelectionController) : base(ingester)
    {
        this.playerSelectionController = playerSelectionController;
    }

    public override UserGridSelectionListener Build()
    {
        return new UserGridSelectionListener(ingester, numTargets, exact, gridFilter, playerSelectionController);
    }
}
