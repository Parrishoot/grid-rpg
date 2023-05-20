using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSetController : ActionSetController<CharacterManager>
{
    public PlayerActionSetUIController playerActionSetUIController;

    protected override void SetupControllers()
    {
        base.SetupControllers();
        playerActionSetUIController.SetupUI(actionControllers);
    }
}
