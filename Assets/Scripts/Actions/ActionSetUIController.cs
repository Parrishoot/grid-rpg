using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetUIController : MonoBehaviour
{
    public GameObject actionUIPrefab;

    public void SetupUI(List<ActionController> actionControllers) {
        foreach(ActionController actionController in actionControllers) {
            GameObject newActionUIObject = Instantiate(actionUIPrefab, transform);
            ActionUIController actionUIController = newActionUIObject.GetComponent<ActionUIController>();
            actionUIController.Init(actionController);
        }
    }
}
