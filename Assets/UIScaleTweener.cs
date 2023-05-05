using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIScaleTweener : UIController
{

    public float tweenTime = .25f;

    public Vector3 openScale = new Vector3(1, 1, 1);

    public Vector3 closedScale = new Vector3(0, 0, 0);

    public void Start() {
        transform.localScale = closedScale;
    } 

    public override void Open() {
        transform.DOScale(openScale, tweenTime).SetEase(Ease.InOutSine);
    }

    public override void Close() {
        transform.DOScale(closedScale, tweenTime).SetEase(Ease.InOutSine);
    }
}
