using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActionController<T>
where T: CharacterManager
{
    [field: SerializeField]
    public Action Action { get; set; }

    protected T characterManager;

    public bool Augmented { get; set; } = false;

    public ActionController() {
     
    }

    public ActionController(Action action, T characterManager) {
        this.Action = action;
        this.characterManager = characterManager;
    }

    public void SetCharacterManager(T characterManager) {
        this.characterManager = characterManager;
    }

    public virtual void Activate() {
        // TODO: MOVE THIS OUT OF HERE
        characterManager.CharacterStats.GetStaminaController().Lose(Action.cost);
        Action.active.Apply(characterManager);
    }

    public void SetAugment() {
        if(!Augmented) {
            Action.passive.Apply(characterManager);
            Augmented = true;
        }
        else {
            Action.passive.Remove(characterManager);
            Augmented = false;
        }
    }

    public bool ActionAvailable() {
        return characterManager.StaminaController.StaminaAvailable(Action.cost);
    }
}
