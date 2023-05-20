using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSetUIController : MonoBehaviour
{
    public GameObject actionUIPrefab;

    public void SetupUI(List<ActionController<PlayerCharacterManager>> actionControllers) {
        foreach(ActionController<PlayerCharacterManager> actionController in actionControllers) {
            GameObject newActionUIObject = Instantiate(actionUIPrefab, transform);
            PlayerActionUIController actionUIController = newActionUIObject.GetComponent<PlayerActionUIController>();
            actionUIController.Init(actionController);
        }
    }
}
