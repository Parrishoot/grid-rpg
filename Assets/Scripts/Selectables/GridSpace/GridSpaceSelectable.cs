using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridSpace))]
public class GridSpaceSelectable : Selectable
{
    GridSpaceStateController GridSpaceStateController { get; set; }

    public override void Start()
    {
        this.selectionManager = SelectionManager.GetInstance();
        Space = GetComponent<GridSpace>();
        StateController = GetComponentInChildren<ISelectableStateController>();
        GridSpaceStateController = (GridSpaceStateController) StateController;

    }

    public override void Select()
    {
        base.Select();

        foreach(Selectable selectable in Space.GetOccupants()) {
            selectable.Select();
        }
    }

    public override void Deselect()
    {
        base.Deselect();

        if(enabled) {
            GridSpaceStateController.SetSelectable();
        }

        foreach(Selectable selectable in Space.GetOccupants()) {
            selectable.Deselect();
        }
    }

    public override void SetSelectable(bool selectable)
    {
        base.SetSelectable(selectable);

        if(enabled) {
            GridSpaceStateController.SetSelectable();
        }
    }

    protected override void OnMouseExit() {
        
        base.OnMouseExit();

        if(enabled && !Selected && !selectionManager.DefaultListenerActive()) {
            GridSpaceStateController.SetSelectable();
        }
    }
}
