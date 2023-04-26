using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public Grid grid;

    public Vector2Int gridSize = new Vector2Int(8, 8);

    public GameObject gridSpacePrefab;

    public Transform gridSpaceParent;

    private GridSpace[,] gridSpaces;

    public override void Awake() {

        base.Awake();

        InitGrid();
    }

    public Vector3 GetClosestCellPosToMouse() {
        Vector3 pos = MouseUtil.GetMousePosOnObject(transform.position);
        return GetClosestCellPosToPos(pos);
    }

    public Vector2Int GetClosestCellToMouse() {
        Vector3 pos = MouseUtil.GetMousePosOnObject(transform.position);
        return GetClosestCellToPos(pos);
    }

    public Vector3 GetClosestCellPosToPos(Vector3 pos) {
        return grid.GetCellCenterWorld(grid.WorldToCell(pos));
    }

    public Vector2Int GetClosestCellToPos(Vector3 pos) {
        Vector3Int gridPos = grid.WorldToCell(pos);
        return new Vector2Int(gridPos.x, gridPos.y);
    }

    public Vector3 GetCellPos(Vector2Int cell, float? yOverride = null) {
        Vector3 pos = grid.GetCellCenterWorld(new Vector3Int(cell.x, cell.y, 0));
        return new Vector3(pos.x, 
                           yOverride ?? pos.y,
                           pos.z);
    }

    public bool IsAtCellCenter(Vector3 worldPos, Vector2Int cell, float buffer = 0f) {
        Vector3 cellCenterPos = GetCellPos(cell);
        return Mathf.Abs(worldPos.x - cellCenterPos.x) <= buffer &&
               Mathf.Abs(worldPos.z - cellCenterPos.z) <= buffer;
    }

    public GridSpace GetGridSpaceAtCell(Vector2Int cell) {
        return gridSpaces[cell.x, cell.y];
    }

    public GridSpace GetClosestGridSpaceToPos(Vector3 pos) {
        Vector2Int cell = GetClosestCellToPos(pos);
        return GetGridSpaceAtCell(cell);
    }

    public float GetCellSize() {
        return grid.cellSize.x;
    }

    private void InitGrid() {
        gridSpaces = new GridSpace[gridSize.x, gridSize.y];

        for(int x = 0; x < gridSize.x; x++) {
            for(int y = 0; y < gridSize.y; y++) {
                GridSpace gridSpace = Instantiate(gridSpacePrefab, GetCellPos(new Vector2Int(x, y)), Quaternion.identity).GetComponent<GridSpace>();
                gridSpace.transform.SetParent(gridSpaceParent, true);
                gridSpace.CellCoords = new Vector2Int(x, y);
                gridSpaces[x, y] = gridSpace.GetComponent<GridSpace>();
            }
        }
    }
}
