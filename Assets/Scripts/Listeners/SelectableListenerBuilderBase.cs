using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableListenerBuilderBase<T>: GridSpaceSelectorBuilder<T, SelectableListenerBuilderBase<T>>
where T: GridSelectionListener
{
    protected int numTargets = 1;

    protected bool exact = false;

    protected SelectableListenerBuilderBase(ISelectableIngester ingester) : base(ingester)
    {

    }

    public SelectableListenerBuilderBase<T> WithNumTargets(int numTargets) {
        this.numTargets = numTargets;
        return this;
    }

    public SelectableListenerBuilderBase<T> WithExactSelection(bool exact) {
        this.exact = exact;
        return this;
    }
}
