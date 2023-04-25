using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITweener : MonoBehaviour
{

    public float tweenTime = .25f;

    public void Start() {
        transform.localScale = new Vector3(1, 0, 1);
    } 

    public void Open() {
        transform.DOScale(Vector3.one, tweenTime).SetEase(Ease.InOutCubic);
    }

    public void Close() {
        transform.DOScale(Vector3.zero, tweenTime).SetEase(Ease.InOutCubic);
    }
}
