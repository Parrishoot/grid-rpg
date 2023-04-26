using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace: MonoBehaviour
{
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

        SelectionManager selectionManager = SelectionManager.GetInstance();

        if(selectionManager.Listener != null) {
            occupant.Space.ReevaluateSpace();
        } 
        
        // Reset the target occuparnt space and check if it's selectable
        occupant.Space = this;

        if(selectionManager.Listener != null) {
            SelectionManager.GetInstance().Listener.ResetSelectableStatus(gridSpaceSelectable);
        }   
    }

    public Selectable[] GetOccupants() {
        return occupantsParentTransform.GetComponentsInChildren<Selectable>();
    }

    public Transform GetOccupantsParentTransform() {
        return occupantsParentTransform;
    }

    public int GetDistance(GridSpace other) {
        return Mathf.Abs(CellCoords.x - other.CellCoords.x) + Mathf.Abs(CellCoords.y - other.CellCoords.y); 
    }

    public int GetDistance(Vector2Int cell) {
        return Mathf.Abs(CellCoords.x - cell.x) + Mathf.Abs(CellCoords.y - cell.y); 
    }

    public void ReevaluateSpace() {
        SelectionManager.GetInstance().Listener.ResetSelectableStatus(gridSpaceSelectable);
    }
}
