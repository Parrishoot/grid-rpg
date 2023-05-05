using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFilter : ISelectableFilter
{
    protected Vector2Int origin;

    protected int range;

    private bool countDiagonals;

    public RangeFilter(Vector2Int origin, int range, bool countDiagonals = false) {
        this.origin = origin;
        this.range = range;
        this.countDiagonals = countDiagonals;
    }

    public virtual bool Filter(GridSpaceSelectable gridSpace)
    {
        int distance = GetDistance(gridSpace);
        return distance != 0 && distance <= range;
        

    }

    protected int GetDistance(GridSpaceSelectable gridSpace) {
        return gridSpace.Space.GetDistance(origin, countDiagonals);
    }
}
