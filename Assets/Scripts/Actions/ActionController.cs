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

    public bool Augmented { get; set; } = false;

    public ActionController(Action action, CharacterManager characterManager) {
        this.Action = action;
        this.characterManager = characterManager;

    }

    public void Activate() {
        // TODO: MOVE THIS OUT OF HERE
        characterManager.CharacterStats.GetStaminaController().Lose(Action.cost);
        SelectionManager.GetInstance().AssignListener(Action.ability.GetListener(characterManager));
    }

    public void SetAugment() {
        if(!Augmented) {
            Action.augment.Apply(characterManager);
            Augmented = true;
        }
        else {
            Action.augment.Remove(characterManager);
            Augmented = false;
        }
    }

    public bool ActionAvailable() {
        return characterManager.StaminaController.StaminaAvailable(Action.cost);
    }
}
