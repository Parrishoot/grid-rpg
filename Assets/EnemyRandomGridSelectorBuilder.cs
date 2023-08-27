using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGridSelectorBuilder : GridSpaceSelectorBuilder<EnemyRandomGridSelector, EnemyRandomGridSelectorBuilder>
{

    public EnemyRandomGridSelectorBuilder(SelectableIngester ingester) : base(ingester)
    {
        
    }

    public override EnemyRandomGridSelector Build()
    {
        return new EnemyRandomGridSelector(ingester, gridFilter, numSelections,exact);
    }
}
