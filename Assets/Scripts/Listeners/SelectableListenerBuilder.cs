using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableListenerBuilder
{
    private ISelectableIngester ingester;

    private int numTargets = 1;

    private bool exact = false;

    private GridFilter gridFilter = new GridFilter();

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
        gridFilter.AddFilter(filter);
        return this;
    }

    public SelectableListenerBuilder WithFilter(GridFilter gridFilter) {
        this.gridFilter = gridFilter;
        return this;
    }

    public GridSelectionListener Build() {
        return new GridSelectionListener(ingester, numTargets, exact, gridFilter);
    }

    public DefaultListener BuildDefault() {
        return new DefaultListener(ingester, numTargets, exact, gridFilter);
    }
}
