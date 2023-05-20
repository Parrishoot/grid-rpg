using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace: MonoBehaviour
{
    [field:SerializeField]
    public Vector2Int CellCoords { get; set; }

    public GridSpaceSelectable gridSpaceSelectable;

    [SerializeField]
    private Transform occupantsParentTransform;

    void Start() {
        gridSpaceSelectable.Space = this;
    }

    public void SetOccupant(Selectable occupant) {
        // Reset the current occupant space and check if it's selectable
        occupant.transform.SetParent(occupantsParentTransform, true);
        
        // Reset the target occuparnt space and check if it's selectable
        occupant.Space = this;
    }

    public Selectable[] GetOccupants() {
        return occupantsParentTransform.GetComponentsInChildren<Selectable>();
    }

    public Transform GetOccupantsParentTransform() {
        return occupantsParentTransform;
    }

    public int GetDistance(GridSpace other, bool countDiagonals = false) {
        return GetDistance(other.CellCoords, countDiagonals); 
    }

    public int GetDistance(Vector2Int cell, bool countDiagonals = false) {
        if(!countDiagonals) {
            return Mathf.Abs(CellCoords.x - cell.x) + Mathf.Abs(CellCoords.y - cell.y);
        }
        else {
            return Mathf.Max(Mathf.Abs(CellCoords.x - cell.x), Mathf.Abs(CellCoords.y - cell.y));
        } 
    }

    public bool IsAccessible() {
        return gridSpaceSelectable.gameObject.activeSelf && GetOccupants().Length == 0;
    }
}
