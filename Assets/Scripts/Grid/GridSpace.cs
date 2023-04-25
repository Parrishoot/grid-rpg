using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace: MonoBehaviour
{
    public Vector2Int CellCoords { get; set; }

    [SerializeField]
    private Transform occupantsParentTransform;

    public void SetOccupant(Selectable occupant) {
        occupant.transform.SetParent(occupantsParentTransform, true);
    }

    public Selectable[] GetOccupants() {
        return occupantsParentTransform.GetComponentsInChildren<Selectable>();
    }

    public int GetDistance(GridSpace other) {
        return Mathf.Abs(CellCoords.x - other.CellCoords.x) + Mathf.Abs(CellCoords.y - other.CellCoords.y); 
    }

    public int GetDistance(Vector2Int cell) {
        return Mathf.Abs(CellCoords.x - cell.x) + Mathf.Abs(CellCoords.y - cell.y); 
    }
}
