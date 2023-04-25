using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : Singleton<SelectionManager>
{

    public Button confirmButton;

    private GridSelectionListener Listener { get; set; }

    private CameraController cameraController;

    private DefaultListener defaultListener;

    void Start() {
        cameraController = CameraController.GetInstance();
        defaultListener = new SelectableListenerBuilder(null).WithRange(int.MaxValue).BuildDefault();
    }
    
    void Update() {

        if(Listener == null) {
            SetupDefaultListener();
        }

        CheckForMouseClickOnSelectable();

        CheckEnableDisableUI();
    }

    public void ProcessListenerSelections() {

        Listener.ProcessSelections();

        SetupDefaultListener();
    }

    public void EndListening() {
        SetupDefaultListener();
    }

    public void AssignListener(GridSelectionListener selectableListener) {
        Listener = selectableListener;
        Listener.BeginListening();
    }

    private void CheckForMouseClickOnSelectable() {
        
        if(Input.GetMouseButtonDown(1)) {
            Listener.Deselect();
            return;
        }

        if(!Input.GetMouseButtonDown(0) || MouseUtil.IsMouseOverUI()) {
            return;
        }

        CheckSelection(MouseUtil.GetSelectableAtMousePos());
    }
    
    public void CheckSelection(GridSpaceSelectable gridSpace) {
        if(Listener != null && gridSpace != null && gridSpace.enabled) {
            Listener.Select(gridSpace);
        }
    }

    private void CheckEnableDisableUI() {
        if(Listener != null && Listener.SelectionFinished()) {
            confirmButton.gameObject.SetActive(true);
        }
        else {
            confirmButton.gameObject.SetActive(false);
        }
    }

    private void SetupDefaultListener() {
        AssignListener(defaultListener);
    }

    public Selectable[] GetSelectables() {
        return FindObjectsOfType<Selectable>();
    }

    public bool DefaultListenerActive() {
        return Listener.Equals(defaultListener);
    }
}
