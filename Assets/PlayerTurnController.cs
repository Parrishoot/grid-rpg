using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnController : CharacterTurnController
{

    public UITweener playerActionMenuTweener;

    public Button endTurnButton;

    public PlayerSelectable playerSelectable;

    public PlayerSelectableStateController playerSelectableStateController;

    public override void BeginTurn()
    {
        playerSelectableStateController.SetTurnActive();
        endTurnButton.gameObject.SetActive(true);
        playerActionMenuTweener.Open();
    }

    public override void EndTurn() {
        endTurnButton.gameObject.SetActive(false);
        playerActionMenuTweener.Close();
        base.EndTurn();
    }
}
