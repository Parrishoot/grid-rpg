using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableListenerBuilder
{
    private ISelectableIngester ingester;

    private int numTargets = 1;

    private bool exact = false;

    private List<ISelectableFilter> filters = new List<ISelectableFilter>();

    public SelectableListenerBuilder(ISelectableIngester ingester) {
        this.ingester = ingester;
    }

    public SelectableListenerBuilder WithNumTargets(int numTargets) {
        this.numTargets = numTargets;
        return this;
    }

    public SelectableListenerBuilder WithExactSelection(bool exact) {
        this.exact = exact;
        return this;
    }

    public SelectableListenerBuilder WithFilter(ISelectableFilter filter) {
        filters.Add(filter);
        return this;
    }

    public GridSelectionListener Build() {
        return new GridSelectionListener(ingester, numTargets, exact, filters);
    }

    public DefaultListener BuildDefault() {
        return new DefaultListener(ingester, numTargets, exact, filters);
    }
}
