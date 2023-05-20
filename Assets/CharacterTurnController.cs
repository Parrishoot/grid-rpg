using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterTurnController: MonoBehaviour
{   
    public CharacterManager characterManager;

    public abstract void BeginTurn();

    public int GetTurnSpeed() {
        return characterManager.CharacterStats.GetControllerForStat(StatType.SPEED).Value;
    }

    public virtual void EndTurn() {
        TurnManager.GetInstance().StartNextTurn();
    }
}
