using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectableStateController : CharacterSelectableStateController
{

    public Material turnActiveMaterial;

   public void SetTurnActive() {
       meshRenderer.material = turnActiveMaterial;
   }
}
