using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySelectionController : CharacterSelectionController
{
    public override ISelectableFilter GetAllyOccupantFilter()
    {
        return new OccupantFilter<EnemySelectable>();
    }

    public override ISelectableFilter GetEnemyOccupantFilter()
    {
        return new OccupantFilter<PlayerSelectable>();
    }

    public override GridSpaceSelector GetSelectAllSelector(ISelectableIngester ingester, GridFilter gridFilter)
    {
        throw new System.NotImplementedException();
    }

    public override GridSpaceSelector GetSelector(ISelectableIngester ingester, GridFilter gridFilter, int numTargets = 1)
    {
        return new EnemyRandomGridSelectorBuilder(ingester).WithFilter(gridFilter)
                                                           .Build();
    }
}
