using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridSpace))]
public class GridSpaceSelectable : Selectable
{
    [field: SerializeField]
    GridSpaceStateController GridSelectableStateController { get; set; }

    public override void Start()
    {
        this.selectionManager = SelectionManager.GetInstance();
        StateControllers = new List<ISelectableStateController>();
        StateControllers.Add(GridSelectableStateController);
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
            GridSelectableStateController.SetSelectable();
        }

        foreach(Selectable selectable in Space.GetOccupants()) {
            selectable.Deselect();
        }
    }

    public override void SetSelectable(bool selectable)
    {
        base.SetSelectable(selectable);

        if(enabled) {
            GridSelectableStateController.SetSelectable();
        }
    }

    protected override void OnMouseExit() {
        
        base.OnMouseExit();

        if(enabled && !Selected && !selectionManager.DefaultListenerActive()) {
            GridSelectableStateController.SetSelectable();
        }
    }
}
