using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerSelectionController : CharacterSelectionController
{

    public Button confirmButton;

    public UserConfirmGridSpaceSelector Listener { get; set; }
    
    void Update() {
        CheckForMouseClickOnSelectable();

        CheckEnableDisableUI();
    }

    public void ProcessListenerSelections() {
        Listener.ProcessSelections();
        Listener = null;
    }

    public void EndListening() {
        if(Listener != null) {
            Listener.Cancel();
            Listener = null;
        }
    }

    public void AssignListener(UserConfirmGridSpaceSelector selectableListener) {
        Listener = selectableListener;
    }

    private void CheckForMouseClickOnSelectable() {
        
        if(MouseUtil.IsMouseOverUI() || Listener == null) {
           return; 
        }

        if(Input.GetMouseButtonDown(1)) {
            Listener.Deselect();
        }

        else if(Input.GetMouseButtonDown(0)) {
            CheckSelection(MouseUtil.GetSelectableAtMousePos());
        }

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

    public GridSpaceSelectable[] GetSelectables() {
        return FindObjectsOfType<GridSpaceSelectable>();
    }

    public override GridSpaceSelector GetSelectAllSelector(ISelectableIngester ingester, GridFilter gridFilter)
    {
        return new GridAutoSelectorBuilder(ingester, this).WithFilter(gridFilter)
                                                          .Build();
    }

    public override GridSpaceSelector GetSelector(ISelectableIngester ingester, GridFilter gridFilter, int numTargets = 1)
    {
        return new UserGridSelectionListenerBuilder(ingester, this).WithFilter(gridFilter)
                                                                   .WithNumTargets(numTargets)
                                                                   .Build();
    }

    public override ISelectableFilter GetEnemyOccupantFilter()
    {
        return new OccupantFilter<EnemySelectable>();
    }

    public override ISelectableFilter GetAllyOccupantFilter()
    {
        return new OccupantFilter<PlayerSelectable>();
    }
}
