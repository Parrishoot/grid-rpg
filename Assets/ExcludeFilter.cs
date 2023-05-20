using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExcludeFilter : ISelectableFilter
{
    private Selectable selectable;

    public ExcludeFilter(Selectable selectable) {
        this.selectable = selectable;
    }

    public bool Filter(GridSpaceSelectable gridSpace)
    {
        return !gridSpace.Space.GetOccupants().ToList().Contains(selectable);
    }
}
