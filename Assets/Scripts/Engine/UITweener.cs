using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITweener : MonoBehaviour
{

    public float tweenTime = .25f;

    public float offScreenPositionX;

    public float onScreenPositionX;

    private RectTransform rectTransform;

    public void Start() {
        rectTransform = transform.GetComponent<RectTransform>();
        onScreenPositionX = rectTransform.anchoredPosition.x;
        offScreenPositionX = -(rectTransform.rect.width + onScreenPositionX);
        rectTransform.anchoredPosition = new Vector3(offScreenPositionX, rectTransform.localPosition.y, rectTransform.localPosition.z);
    } 

    public void Open() {
        rectTransform.DOAnchorPosX(onScreenPositionX, tweenTime).SetEase(Ease.InOutCubic);
    }

    public void Close() {
        rectTransform.DOAnchorPosX(offScreenPositionX, tweenTime).SetEase(Ease.InOutCubic);
    }
}
