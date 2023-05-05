using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public int GCost { get; set; } = 0;
    public int HCost { get; set; } = 0;
    public int FCost { get; set; } = 0;

    public Vector2Int Origin { get; set; }

    public PathNode CameFrom { get; set; }

    private SerializableMatrix<PathNode> grid;

    public bool Accessible { get; set; }

    public PathNode(Vector2Int origin, SerializableMatrix<PathNode> grid, bool accessible) {
        Origin = origin;
        this.grid = grid;
        GCost = 0;
        HCost = 0;
        FCost = 0;
        CameFrom = null;
        Accessible = accessible;
    }

    public void CalculateFCost() {
        FCost = GCost + HCost;
    }
}
