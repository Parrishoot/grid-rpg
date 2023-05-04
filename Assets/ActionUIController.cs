using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class ActionUIController : MonoBehaviour
{
    public Button button;

    public TMP_Text text;

    private UITweener parentPanelTweener;

    public void Init(ActionController actionController) {

        parentPanelTweener = GetComponentInParent<UITweener>();

        button.onClick.AddListener(delegate() {
                actionController.Activate();
                parentPanelTweener.Close();
            }
        );

        text.SetText(actionController.Action.actionName);
    }
}
