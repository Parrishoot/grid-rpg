using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnManager : Singleton<TurnManager>
{
    private Queue<CharacterTurnController> currentTurnQueue = new Queue<CharacterTurnController>();

    public void Start() {

    }

    public void StartRound() {
        
        List<CharacterTurnController> characterTurnControllers = FindObjectsOfType<CharacterTurnController>().ToList();
        currentTurnQueue = new Queue<CharacterTurnController>(characterTurnControllers.OrderBy(x => x.GetTurnSpeed()).ToList());

        StartNextTurn();
    }

    public void StartNextTurn() {
        if(currentTurnQueue.Count != 0) {
            CharacterTurnController characterTurnController = currentTurnQueue.Dequeue();
            characterTurnController.BeginTurn();
        }
        else {
            StartRound();
        }
    }
}
