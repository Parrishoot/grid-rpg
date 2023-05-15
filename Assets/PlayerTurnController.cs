using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnControler : CharacterTurnController
{
    public override void BeginTurn()
    {
        EndTurn();
    }
}
