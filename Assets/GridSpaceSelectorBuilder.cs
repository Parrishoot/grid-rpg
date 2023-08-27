using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridSpaceSelectorBuilder<T, TBuilder> 
where T: GridSpaceSelector
where TBuilder: GridSpaceSelectorBuilder<T, TBuilder>
{
    protected GridFilter gridFilter = new GridFilter();

    protected SelectableIngester ingester;

    protected int numSelections = 1;

    protected bool exact = true;

    public GridSpaceSelectorBuilder(SelectableIngester ingester) {
        this.ingester = ingester;
    }

    public TBuilder WithFilter(ISelectableFilter filter) {
        this.gridFilter.AddFilter(filter);
        return (TBuilder) this;
    }

    public TBuilder WithFilter(GridFilter filter) {
        this.gridFilter = filter;
        return (TBuilder) this;
    }

    public TBuilder WithNumSelections(int numSelections) {
        this.numSelections = numSelections;
        return (TBuilder) this;
    }

    public TBuilder WithExact(bool exact) {
        this.exact = exact;
        return (TBuilder) this;
    }

    public abstract T Build();
}
