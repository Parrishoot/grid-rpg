using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMover : MonoBehaviour
{
    public Vector2Int targetGridPos = new Vector2Int(0, 0);

    public Vector2Int currentGridPos = new Vector2Int(0, 0);

    public float movementSpeed = 10f;

    private GridManager gridManager;

    private Selectable selectable;

    public void Start() {
        gridManager = GridManager.GetInstance();
        selectable = GetComponent<Selectable>();
        transform.position = gridManager.GetCellPos(currentGridPos, transform.position.y);
        targetGridPos = currentGridPos;
        gridManager.GetGridSpaceAtCell(targetGridPos).SetOccupant(selectable);
    }

    public void Update() {

        if(!gridManager.IsAtCellCenter(transform.position, targetGridPos)) {

            Vector3 targetCellWorldPos = gridManager.GetCellPos(targetGridPos);

            if(transform.position.x != targetCellWorldPos.x) {
                transform.Translate(GetFrameMovement(transform.position.x, targetCellWorldPos.x), 0, 0);
            }
            else if(transform.position.z != targetCellWorldPos.z) {
                transform.Translate(0, 0, GetFrameMovement(transform.position.z, targetCellWorldPos.z));
            }
        }
        else if (currentGridPos != targetGridPos) {
            gridManager.GetGridSpaceAtCell(targetGridPos).SetOccupant(selectable);
            currentGridPos = targetGridPos;
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
        this.targetGridPos = targetCell;
    }
}
