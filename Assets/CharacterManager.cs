using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [field: SerializeField]
    public GridMover CharacterGridMover { get; set; }

    [field: SerializeField]
    public CharacterStats CharacterStats { get; set; }

    [field: SerializeField]
    public HealthController HealthController { get; set; }

    [field: SerializeField]
    public StaminaController StaminaController { get; set; }
}
