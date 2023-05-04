using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActionController
{
    [field: SerializeField]
    public Action Action { get; set; }

    private CharacterManager characterManager;

    private bool augmented = false;

    public ActionController(Action action, CharacterManager characterManager) {
        this.Action = action;
        this.characterManager = characterManager;

    }

    public void Activate() {
        SelectionManager.GetInstance().AssignListener(Action.ability.GetListener(characterManager));
    }
}
