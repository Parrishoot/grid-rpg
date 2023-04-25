using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionLerper))]
public class GridSnapper : MonoBehaviour
{

    public Grid grid;

    public Vector2Int gridPos;

    private PositionLerper positionLerper;

    private GridManager gridManager;

    // Start is called before the first frame update
    void Start()
    {
        positionLerper = GetComponent<PositionLerper>();
        gridManager = GridManager.GetInstance();
    }

    private void OnMouseUp() {
        SnapPiece();
    }
    
    private void OnMouseDown() {
        UpdatePiece();
    }

    private void OnMouseDrag() {
        UpdatePiece();
    }

    private void SnapPiece() {
        Vector3 closestCellPos = gridManager.GetClosestCellPosToMouse();
        positionLerper.SetSnapTarget(new Vector3(closestCellPos.x, transform.position.y, closestCellPos.z));
    }

    private void UpdatePiece() {
        Vector3 mousePos = MouseUtil.GetMousePosOnObject(gridManager.transform.position);
        positionLerper.SetSmoothFollowTarget(new Vector3(mousePos.x, transform.position.y, mousePos.z));
    }
}
