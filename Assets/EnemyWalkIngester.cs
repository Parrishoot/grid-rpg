using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkIngester : CharacterWalkIngester
{

    private CharacterTurnController enemyTurnController;

    public EnemyWalkIngester(EnemyTurnController enemyTurnController, GridMover gridMover) : base(gridMover)
    {   
        this.enemyTurnController = enemyTurnController;
    }

    protected override void OnDestinationReached()
    {
        enemyTurnController.EndTurn();
        gridMover.RemoveOnDestinationReachedEvent(OnDestinationReached);
    }
}
