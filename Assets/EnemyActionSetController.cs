using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionSetController : ActionSetController<CharacterManager>
{
    public void PerformAction() {
        ActionController<CharacterManager> actionController = actionControllers[Random.Range(0, actionControllers.Count - 1)];
        actionController.Activate();
    }
}
