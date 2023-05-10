using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserGridSelectionListenerBuilderBase<T>: GridSpaceSelectorBuilder<T, UserGridSelectionListenerBuilderBase<T>>
where T: UserGridSelectionListener
{
    protected int numTargets = 1;

    protected bool exact = false;

    protected UserGridSelectionListenerBuilderBase(ISelectableIngester ingester) : base(ingester)
    {

    }

    public UserGridSelectionListenerBuilderBase<T> WithNumTargets(int numTargets) {
        this.numTargets = numTargets;
        return this;
    }

    public UserGridSelectionListenerBuilderBase<T> WithExactSelection(bool exact) {
        this.exact = exact;
        return this;
    }
}
