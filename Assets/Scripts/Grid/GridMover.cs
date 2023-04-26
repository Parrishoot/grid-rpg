using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMover : MonoBehaviour
{
    public Vector2Int TargetGridPos { get; set; }

    public Vector2Int CurrentGridPos { get; set; }

    public float movementSpeed = 10f;

    private GridManager gridManager;

    private Selectable selectable;

    public void Start() {
        gridManager = GridManager.GetInstance();
        selectable = GetComponent<Selectable>();
        InitPosition();
    }

    public void Update() {

        if(!gridManager.IsAtCellCenter(transform.position, TargetGridPos)) {

            Vector3 targetCellWorldPos = gridManager.GetCellPos(TargetGridPos);

            if(transform.position.x != targetCellWorldPos.x) {
                transform.Translate(GetFrameMovement(transform.position.x, targetCellWorldPos.x), 0, 0);
            }
            else if(transform.position.z != targetCellWorldPos.z) {
                transform.Translate(0, 0, GetFrameMovement(transform.position.z, targetCellWorldPos.z));
            }
        }
        else if (CurrentGridPos != TargetGridPos) {
            gridManager.GetGridSpaceAtCell(TargetGridPos).SetOccupant(selectable);
            CurrentGridPos = TargetGridPos;
        }
        
    }

    public float GetFrameMovement(float currentPosition, float targetPosition) {
        if(currentPosition < targetPosition) {
            return Mathf.Min(movementSpeed * Time.deltaTime, targetPosition - currentPosition);
        }
        else {
            return Mathf.Max(-(movementSpeed * Time.deltaTime), targetPosition - currentPosition);
        }
    }

    public void SetGridTarget(Vector2Int targetCell) {
        this.TargetGridPos = targetCell;
    }

    private void InitPosition() {
        GridSpace closestSpace = gridManager.GetClosestGridSpaceToPos(transform.position);
        TargetGridPos = closestSpace.CellCoords;
        CurrentGridPos = closestSpace.CellCoords;

        gridManager.GetGridSpaceAtCell(TargetGridPos).SetOccupant(selectable);

        transform.position = gridManager.GetCellPos(CurrentGridPos, transform.position.y);
    }
}
