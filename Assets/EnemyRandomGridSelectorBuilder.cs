using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGridSelectorBuilder : GridSpaceSelectorBuilder<EnemyRandomGridSelector, EnemyRandomGridSelectorBuilder>
{
    private int numSelections = 1;

    public EnemyRandomGridSelectorBuilder(ISelectableIngester ingester) : base(ingester)
    {
        
    }

    public EnemyRandomGridSelectorBuilder WithNumSelections(int numSelections) {
        this.numSelections = numSelections;
        return this;
    }

    public override EnemyRandomGridSelector Build()
    {
        return new EnemyRandomGridSelector(ingester, gridFilter, numSelections);
    }
}
