using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionSetController : MonoBehaviour
{
    public List<Action> availableActions;

    public ActionSetUIController actionSetUIController;

    public CharacterManager characterManager;

    private List<ActionController> actionControllers;

    private void Start() {
        SetupControllers();
    }

    private void SetupControllers() {
        actionControllers = availableActions.Select(x => new ActionController(x, characterManager)).ToList();
        actionSetUIController.SetupUI(actionControllers);
    }
}
