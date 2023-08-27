using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WalkableRangeFilter : RangeFilter
{
    private PathTracker currentPathTracker;

    public WalkableRangeFilter(Vector2Int origin, int range, PathTracker currentPathTracker, bool countDiagonals = false) : base(origin, range, countDiagonals)
    {
        this.currentPathTracker = currentPathTracker;
    }

    public override bool Filter(GridSpaceSelectable gridSpace)
    {

        List<Vector2Int> currentPath = currentPathTracker.GetPath();
        int remainingDistance = range - (Mathf.Max(currentPath.Count - 1, 0));

        if(remainingDistance <= 0) {
            return false;
        }

        List<PathNode> path = null;
        Vector2Int startingPosition = currentPath.Count.Equals(0) ? origin : currentPath.Last();

        path = GridManager.GetInstance().FindPath(startingPosition, gridSpace.Space.CellCoords, range);

        return path != null && path.Count <= remainingDistance;
    }
}
