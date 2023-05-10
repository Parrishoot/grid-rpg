using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class ActionUIController : MonoBehaviour
{
    public MultiClickableButton button;

    public TMP_Text nameText;

    public TMP_Text staminaCostText;

    public TMP_Text descriptionText;

    public UIScaleTweener descriptionTweener;

    private UITweener parentPanelTweener;

    private ActionController actionController;

    public Color baseColor;

    public Color augmentedColor;

    public void Start() {
        this.baseColor = this.button.GetComponent<Image>().color;
    }

    public void Init(ActionController actionController) {

        parentPanelTweener = GetComponentInParent<UITweener>();

        button.onClick.AddListener(delegate() {
                actionController.Activate();
                parentPanelTweener.Close();
            }
        );

        button.onRightClick.AddListener(delegate() {
                actionController.SetAugment();
            }
        );

        nameText.SetText(actionController.Action.actionName);
        staminaCostText.SetText(actionController.Action.cost.ToString());
        descriptionText.SetText(actionController.Action.ability.GetDescription());

        this.actionController = actionController;
    }

    public void Update() {
        button.interactable = actionController.ActionAvailable() && !actionController.Augmented;
        Debug.Log(button.interactable);
        button.GetComponent<Image>().color = actionController.Augmented ? augmentedColor : baseColor;
    }

    public void ShowDescription() {
        descriptionTweener.Open();
    }

    public void HideDescription() {
        descriptionTweener.Close();
    }
}
