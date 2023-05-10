using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableListenerBuilder<T>
where T: GridSelectionListener, new()
{
    private ISelectableIngester ingester;

    private int numTargets = 1;

    private bool exact = false;

    private GridFilter gridFilter = new GridFilter();

    public SelectableListenerBuilder(ISelectableIngester ingester) {
        this.ingester = ingester;
    }

    public SelectableListenerBuilder<T> WithNumTargets(int numTargets) {
        this.numTargets = numTargets;
        return this;
    }

    public SelectableListenerBuilder<T> WithExactSelection(bool exact) {
        this.exact = exact;
        return this;
    }

    public SelectableListenerBuilder<T> WithFilter(ISelectableFilter filter) {
        gridFilter.AddFilter(filter);
        return this;
    }

    public SelectableListenerBuilder<T> WithFilter(GridFilter gridFilter) {
        this.gridFilter = gridFilter;
        return this;
    }

    public T Build() {
        T listener = new T();
        listener.Init(ingester, numTargets, exact, gridFilter);
        return listener;
    }
}
