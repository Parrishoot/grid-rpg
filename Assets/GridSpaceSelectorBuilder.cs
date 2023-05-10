using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridSpaceSelectorBuilder<T, TBuilder> 
where T: GridSpaceSelector
where TBuilder: GridSpaceSelectorBuilder<T, TBuilder>
{
    protected GridFilter gridFilter = new GridFilter();

    protected ISelectableIngester ingester;

    public GridSpaceSelectorBuilder(ISelectableIngester ingester) {
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

    public abstract T Build();
}
