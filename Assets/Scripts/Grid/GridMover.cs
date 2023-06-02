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

    private Queue<Vector2Int> path = new Queue<Vector2Int>();

    public delegate void OnDestinationReached(); 
    OnDestinationReached onDestinationReached;

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
        else if(path.Count != 0) {
            TargetGridPos = path.Dequeue();
        }
        else if (CurrentGridPos != TargetGridPos) {

            onDestinationReached?.Invoke();
            onDestinationReached = null;

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

    public void AddOnDestinationReachedEvent(OnDestinationReached onDestinationReachedEvent) {
        onDestinationReached += onDestinationReachedEvent;
    }

    public void RemoveOnDestinationReachedEvent(OnDestinationReached onDestinationReachedEvent) {
        onDestinationReached -= onDestinationReachedEvent;
    }

    public void SetPath(List<Vector2Int> path, OnDestinationReached onDestinationReachedEvent = null) {
        
        if(onDestinationReachedEvent != null) {
            onDestinationReached += onDestinationReachedEvent;
        }


        this.path = new Queue<Vector2Int>(path);
        TargetGridPos = this.path.Dequeue();
    }

    public void SetGridTarget(Vector2Int targetCell) 
    {
        SetPath(new List<Vector2Int>() { targetCell } );
    }

    private void InitPosition() {
        GridSpace closestSpace = gridManager.GetClosestGridSpaceToPos(transform.position);
        TargetGridPos = closestSpace.CellCoords;
        CurrentGridPos = closestSpace.CellCoords;

        gridManager.GetGridSpaceAtCell(TargetGridPos).SetOccupant(selectable);

        transform.position = gridManager.GetCellPos(CurrentGridPos, transform.position.y);
    }
}
