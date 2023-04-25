using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableListenerBuilder
{
    private ISelectableIngester ingester;

    private Vector2Int origin = new Vector2Int(0, 0);

    private int numTargets = 1;

    private int range = 1;

    private bool exact = false;

    private List<ISelectableFilter> filters = new List<ISelectableFilter>();

    public SelectableListenerBuilder(ISelectableIngester ingester) {
        this.ingester = ingester;
    }

    public SelectableListenerBuilder WithNumTargets(int numTargets) {
        this.numTargets = numTargets;
        return this;
    }

    public SelectableListenerBuilder WithRange(int range) {
        this.range = range;
        return this;
    }

    public SelectableListenerBuilder WithExactSelection(bool exact) {
        this.exact = exact;
        return this;
    }

    public SelectableListenerBuilder WithOrigin(Vector2Int origin) {
        this.origin = origin;
        return this;
    }

    public SelectableListenerBuilder WithFilter(ISelectableFilter filter) {
        filters.Add(filter);
        return this;
    }

    public GridSelectionListener Build() {
        return new GridSelectionListener(ingester, origin, numTargets, range, exact, filters);
    }

    public DefaultListener BuildDefault() {
        return new DefaultListener(ingester, origin, numTargets, range, exact, filters);
    }
}
