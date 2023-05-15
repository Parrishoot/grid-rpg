using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : CharacterTurnController
{
    public override void BeginTurn()
    {
        EnemyWalkIngester walkIngester = new EnemyWalkIngester(this, characterManager.CharacterGridMover);
        new EnemyRandomGridSelectorBuilder(walkIngester).WithFilter(new WalkableRangeFilter(characterManager.CharacterGridMover.CurrentGridPos, 2))
                                                        .Build()
                                                        .GatherSelections();
    }
}
