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

    public UITweener actionSetPanelUITweener;
    
    void Update() {
        CheckForMouseClickOnSelectable();
        CheckEnableDisableUI();
    }

    public void ProcessListenerSelections() {
        Listener.ProcessSelections();
        actionSetPanelUITweener.Open();
        Listener = null;
    }

    public void EndListening() {
        if(Listener != null) {
            Listener.Cancel();
            actionSetPanelUITweener.Open();
            Listener = null;
        }
    }

    public void AssignListener(UserConfirmGridSpaceSelector selectableListener) {
        Listener = selectableListener;
        actionSetPanelUITweener.Close();
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

        // Check if the confirm button should be enabled
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

    public override GridSpaceSelector GetSelectAllSelector(SelectableIngester ingester, GridFilter gridFilter)
    {
        return new GridAutoSelectorBuilder(ingester, this).WithFilter(gridFilter)
                                                          .Build();
    }

    public override GridSpaceSelector GetSelector(SelectableIngester ingester, GridFilter gridFilter, int numTargets = 1, bool exact = true)
    {
        return new UserGridSelectionListenerBuilder(ingester, this).WithFilter(gridFilter)
                                                                   .WithNumSelections(numTargets)
                                                                   .WithExact(exact)
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
