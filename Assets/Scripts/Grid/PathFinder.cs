using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinder
{
    private SerializableMatrix<PathNode> grid;

    public PathFinder(SerializableMatrix<GridSpace> grid) {
        this.grid = new SerializableMatrix<PathNode>(grid.Width, grid.Height);
        this.grid.SetValues(grid.GetValues().Select(x => new PathNode(x.CellCoords, this.grid, x.IsAccessible())).ToArray());
    }

    public List<PathNode> FindPath(Vector2Int start, Vector2Int end) {

        PathNode startNode = grid[start.x, start.y];
        PathNode endNode = grid[end.x, end.y];

        List<PathNode> openList = new List<PathNode>() { startNode };
        List<PathNode> closedList = new List<PathNode>();

        // Initialize Path
        for(int x = 0; x < this.grid.Width; x++) {
            for(int y = 0; y < this.grid.Width; y++) {
                PathNode pathNode = this.grid[x, y];
                pathNode.GCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.CameFrom = null;
            }
        }

        startNode.GCost = 0;
        startNode.HCost = CalculateDistance(startNode, endNode); 
        startNode.CalculateFCost();

        // Cycle to calculate costs
        while(openList.Count > 0) {

            PathNode currentNode = GetLowestFCostNode(openList);
            
            // We reached our destination
            if(currentNode == endNode) {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach(PathNode neighborNode in GetNeighborList(currentNode)) {
                
                if(closedList.Contains(neighborNode)) {
                    continue;
                }

                if(!neighborNode.Accessible) {
                    closedList.Add(neighborNode);
                    continue;
                }

                int tentativeGCost = currentNode.GCost + CalculateDistance(currentNode, neighborNode);

                if(tentativeGCost < neighborNode.GCost) {
                    neighborNode.CameFrom = currentNode;
                    neighborNode.GCost = tentativeGCost;
                    neighborNode.HCost = CalculateDistance(neighborNode, endNode);
                    neighborNode.CalculateFCost();
                }

                if(!openList.Contains(neighborNode)) {
                    openList.Add(neighborNode);
                }
            }
        }

        // Inaccessible endpoint
        return null;
    }

    private List<PathNode> GetNeighborList(PathNode currentNode) {
        
        List<PathNode> neighborList = new List<PathNode>();

        if(currentNode.Origin.x > 0) {
            neighborList.Add(this.grid[currentNode.Origin.x - 1, currentNode.Origin.y]);
        }

        if(currentNode.Origin.x < this.grid.Width - 1) {
            neighborList.Add(this.grid[currentNode.Origin.x + 1, currentNode.Origin.y]);
        }

        if(currentNode.Origin.y > 0) {
            neighborList.Add(this.grid[currentNode.Origin.x, currentNode.Origin.y - 1]);
        }

        if(currentNode.Origin.y < this.grid.Height - 1) {
            neighborList.Add(this.grid[currentNode.Origin.x, currentNode.Origin.y + 1]);
        }

        return neighborList;
    }

    private List<PathNode> CalculatePath(PathNode endNode) {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while(currentNode.CameFrom != null) {
            path.Add(currentNode.CameFrom);
            currentNode = currentNode.CameFrom;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistance(PathNode a, PathNode b) {
        int xDistance = Mathf.Abs(a.Origin.x - b.Origin.x);
        int yDistance = Mathf.Abs(a.Origin.y - b.Origin.y);
        return Mathf.Abs(xDistance - yDistance);
    }

    // TODO: Look into Priortiy Queue
    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList) {

        PathNode lowestFCostPathNode = pathNodeList[0];

        for(int i = 1; i < pathNodeList.Count; i++) {
            if(pathNodeList[i].FCost < lowestFCostPathNode.FCost) {
                lowestFCostPathNode = pathNodeList[i];
            }
        }

        return lowestFCostPathNode;
    }
}
