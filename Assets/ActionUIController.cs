using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class ActionUIController : MonoBehaviour
{
    public Button button;

    public TMP_Text nameText;

    public TMP_Text staminaCostText;

    public TMP_Text descriptionText;

    public UIScaleTweener descriptionTweener;

    private UITweener parentPanelTweener;

    private ActionController actionController;

    public void Init(ActionController actionController) {

        parentPanelTweener = GetComponentInParent<UITweener>();

        button.onClick.AddListener(delegate() {
                actionController.Activate();
                parentPanelTweener.Close();
            }
        );

        nameText.SetText(actionController.Action.actionName);
        staminaCostText.SetText(actionController.Action.cost.ToString());
        descriptionText.SetText(actionController.Action.ability.GetDescription());

        this.actionController = actionController;
    }

    public void Update() {
        button.interactable = actionController.ActionAvailable();
    }

    public void ShowDescription() {
        descriptionTweener.Open();
    }

    public void HideDescription() {
        descriptionTweener.Close();
    }
}
