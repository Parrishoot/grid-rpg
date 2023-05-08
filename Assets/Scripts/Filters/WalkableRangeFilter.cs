using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableRangeFilter : RangeFilter
{
    public WalkableRangeFilter(Vector2Int origin, int range, bool countDiagonals = false) : base(origin, range, countDiagonals)
    {

    }

    public override bool Filter(GridSpaceSelectable gridSpace)
    {
        bool inRange = base.Filter(gridSpace);

        if(!inRange) {
            return false;
        }

        List<PathNode> path = null;

        if(GetDistance(gridSpace) <= range) {
            path = GridManager.GetInstance().FindPath(origin, gridSpace.Space.CellCoords, range);
        }

        gridSpace.SetPath(path);
        
        return path != null;
    }
}
