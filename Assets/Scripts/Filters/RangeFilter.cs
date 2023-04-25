using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFilter : ISelectableFilter
{
    private Vector2Int origin;

    private int range;

    public RangeFilter(Vector2Int origin, int range) {
        this.origin = origin;
        this.range = range;
    }

    public bool Filter(Selectable selectable)
    {
        int distance = selectable.Space.GetDistance(origin);
        return distance != 0 && distance <= range;
    }
}
