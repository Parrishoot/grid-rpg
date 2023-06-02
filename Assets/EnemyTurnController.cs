using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : CharacterTurnController
{
    public EnemyActionSetController enemyActionSetController;

    public override void BeginTurn()
    {
        
        enemyActionSetController.PerformAction();
    }
}
