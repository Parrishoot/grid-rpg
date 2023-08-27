using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathTracker
{
    Stack<List<Vector2Int>> currentPathSegments = new Stack<List<Vector2Int>>();

    public void AddSegment(List<PathNode> pathSegment) {
        List<Vector2Int> pathSegmentOfVectors = pathSegment.Select(x => x.Origin).ToList();
        AddSegment(pathSegmentOfVectors);
    }

    public void AddSegment(List<Vector2Int> pathSegment) {
        currentPathSegments.Push(pathSegment);
    }

    public void RemoveSegment() {
        currentPathSegments.Pop();
    }

    public List<Vector2Int> GetPath() {

        // If there isn't a path, return the empty path
        List<Vector2Int> currentPath = new List<Vector2Int>();

        if(currentPathSegments.Count.Equals(0)) {
            return currentPath;
        }

        // If there is a path segment, grab the first chunk
        List<List<Vector2Int>> pathSegments = currentPathSegments.ToList();

        currentPath.AddRange(pathSegments[0]);

        if(currentPathSegments.Count.Equals(1)) {
            return currentPath;
        }

        // If there is more than one chunk, create the flattened path
        foreach(List<Vector2Int> pathSegment in pathSegments) {
            currentPath.AddRange(pathSegment.GetRange(1, pathSegment.Count - 1));
        }

        return currentPath;
    }

    public int GetPathDistance() {
        return GetPath().Count;
    }
}
