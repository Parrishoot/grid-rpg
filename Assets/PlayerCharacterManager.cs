using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterManager : CharacterManager
{
    [field:SerializeReference]
    public PlayerSelectionController SelectionController;
}
