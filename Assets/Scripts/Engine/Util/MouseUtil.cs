using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class MouseUtil
{
    public static Vector3 NO_MOUSE_POS = new Vector3(-9999, -9999, -9999);

    public static Vector3 GetMousePosOnObject(Vector3 planePos) {
        Plane plane = new Plane(Vector3.up, planePos);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        if (plane.Raycast(ray, out dist))
        {
            return ray.GetPoint(dist);
        }
        return NO_MOUSE_POS;
    }

    public static GridSpaceSelectable GetSelectableAtMousePos() {
        RaycastHit  hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
        if (Physics.Raycast(ray, out hit)) {
            return hit.transform.gameObject.GetComponent<GridSpaceSelectable>();
        }

        return null;
    }

    public static Vector3 GetMousePositionInWorld() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static bool IsMouseOverUI() {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
