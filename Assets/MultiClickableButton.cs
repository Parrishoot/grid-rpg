using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;

public class MultiClickableButton : Button, IPointerClickHandler {
    [SerializeField]
    public UnityEvent onRightClick;

    [SerializeField]
    public UnityEvent onMiddleClick;

    public override void OnPointerClick(PointerEventData eventData) {

        base.OnPointerClick(eventData);

        if(eventData.button == PointerEventData.InputButton.Right) {
            onRightClick?.Invoke();
        }
        else if(eventData.button == PointerEventData.InputButton.Middle) {
            onMiddleClick?.Invoke();
        }
    }
}
