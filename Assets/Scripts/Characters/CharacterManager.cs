using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterManager : MonoBehaviour
{

    [field: SerializeField]
    public GridMover CharacterGridMover { get; set; }

    [field: SerializeField]
    public CharacterStats CharacterStats { get; set; }

    [field: SerializeField]
    public StaminaController StaminaController { get; set; }

    [field: SerializeField]
    public Selectable CharacterSelectable { get; set; }

    [field: SerializeField]
    public CharacterSelectionController SelectionController { get; set; }

    [field: SerializeField]
    public CharacterTurnController CharacterTurnController { get; set; }
}
