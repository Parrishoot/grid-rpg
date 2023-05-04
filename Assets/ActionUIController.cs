using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class ActionUIController : MonoBehaviour
{
    public Button button;

    public TMP_Text nameText;

    public TMP_Text descriptionText;

    public UIScaleTweener descriptionTweener;

    private UITweener parentPanelTweener;

    public void Init(ActionController actionController) {

        parentPanelTweener = GetComponentInParent<UITweener>();

        button.onClick.AddListener(delegate() {
                actionController.Activate();
                parentPanelTweener.Close();
            }
        );

        nameText.SetText(actionController.Action.actionName);
        descriptionText.SetText(actionController.Action.ability.GetDescription());
    }

    public void ShowDescription() {
        descriptionTweener.Open();
    }

    public void HideDescription() {
        descriptionTweener.Close();
    }
}
