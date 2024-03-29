using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity;
using UnityEngine;

public class Selectable : MonoBehaviour {

    public bool Selected { get; set; } = false;

    public bool Hovering { get; set; } = false;

    [field: SerializeField]
    public GridSpace Space { get; set; }

    [field: SerializeField]
    public List<ISelectableStateController> StateControllers { get; set; } = new List<ISelectableStateController>();

    protected virtual void Update() {
        Hovering = false;
    }

    public virtual void Select() {
        Selected = true;

        foreach(ISelectableStateController stateController in StateControllers) {
            stateController.SetSelected();
        }
    }

    public virtual void Deselect() {
        Reset();
    }

    protected virtual void Reset() {
        Selected = false;
        
        foreach(ISelectableStateController stateController in StateControllers) {
            stateController.SetIdle();
        }
    }

    public virtual void Start() {

        if(Space == null) {    
            Space = GridManager.GetInstance().GetClosestGridSpaceToPos(transform.position);
        }

        StateControllers = new List<ISelectableStateController>(GetComponents<ISelectableStateController>());
        Space.SetOccupant(this);
    }

    public virtual GameObject GetGameObject() {
        return gameObject;
    }

    protected virtual void OnMouseEnter() {
        if(!MouseUtil.IsMouseOverUI() && enabled) {
            Hovering = true;

            foreach(ISelectableStateController stateController in StateControllers) {
                stateController.SetHover();
            }
        }
    }

    protected virtual void OnMouseExit() {
        
        if(!Selected && enabled) {
            foreach(ISelectableStateController stateController in StateControllers) {
                stateController.SetIdle();
            }
        }
        else if(enabled){
            foreach(ISelectableStateController stateController in StateControllers) {
                stateController.SetSelected();
            }
        }

        Hovering = false;
    }

    public virtual void SetSelectable(bool selectable) {
        
        enabled = selectable;

        if(!enabled) {
            Selected = false;

            SetStateControllersIdle();
        }
    }

    public void SetStateControllersIdle() {
        foreach(ISelectableStateController stateController in StateControllers) {
            stateController.SetIdle();
        }
    }

    public void SetStateControllersHover() {
        foreach(ISelectableStateController stateController in StateControllers) {
            stateController.SetHover();
        }
    }

    public void SetStateControllersSelected() {
        foreach(ISelectableStateController stateController in StateControllers) {
            stateController.SetSelected();
        }
    }

    protected void SetStateControllersHoverSelected() {
        foreach(ISelectableStateController stateController in StateControllers) {
            stateController.SetSelected();
        }
    }
}
