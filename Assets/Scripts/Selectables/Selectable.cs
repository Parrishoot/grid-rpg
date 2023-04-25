using Unity;
using UnityEngine;

public class Selectable : MonoBehaviour {

    protected SelectionManager selectionManager;

    public bool Selected { get; set; } = false;

    public bool Hovering { get; set; } = false;

    public GridSpace Space { get; set; }

    public ISelectableStateController StateController { get; set; }

    protected virtual void Update() {
        Hovering = false;
    }

    public virtual void Select() {
        Selected = true;
        StateController.SetSelected();
    }

    public virtual void Deselect() {
        Reset();
    }

    protected virtual void Reset() {
        Selected = false;
        StateController.SetIdle();
    }

    public virtual void Start() {
        this.selectionManager = SelectionManager.GetInstance();
        Space = GridManager.GetInstance().GetClosestGridSpaceToPos(transform.position);
        StateController = GetComponent<ISelectableStateController>();
        Space.SetOccupant(this);
    }

    public virtual GameObject GetGameObject() {
        return gameObject;
    }

    protected virtual void OnMouseEnter() {
        if(!MouseUtil.IsMouseOverUI()) {
            Hovering = true;
            StateController.SetHover();
        }
    }

    protected virtual void OnMouseExit() {
        
        if(!Selected) {
            StateController.SetIdle();
        }
        else {
            StateController.SetSelected();
        }

        Hovering = false;
    }

    public virtual void SetSelectable(bool selectable) {
        
        enabled = selectable;

        if(!enabled) {
            Selected = false;
            StateController.SetIdle();
        }
    }
}
