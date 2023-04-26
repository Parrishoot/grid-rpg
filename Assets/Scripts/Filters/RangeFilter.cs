using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFilter : ISelectableFilter
{
    private Vector2Int origin;

    private int range;

    private bool countDiagonals;

    public RangeFilter(Vector2Int origin, int range, bool countDiagonals = false) {
        this.origin = origin;
        this.range = range;
        this.countDiagonals = countDiagonals;
    }

    public bool Filter(GridSpaceSelectable gridSpace)
    {
        int distance = gridSpace.Space.GetDistance(origin, countDiagonals);
        return distance != 0 && distance <= range;
    }
}
