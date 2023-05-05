using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridSpaceStateController : MonoBehaviour, ISelectableStateController
{
    public SpriteRenderer spriteRenderer;

    private Sequence activeSequence;

    void Start() {
        SetIdle();
    }

    public void SetHover() {
        SetTweenSequence();        
    }

    public void SetIdle() {

        spriteRenderer.color = Color.white;

        KillActiveSequence();
    }

    public void SetSelected() {
        spriteRenderer.color = Color.red;
        SetTweenSequence();
    }

    private void SetTweenSequence() {
        KillActiveSequence();

        activeSequence = DOTween.Sequence()
            .Append(transform.DOScale(Vector3.one * .8f, .25f))
            .Append(transform.DOScale(Vector3.one, .25f));
        activeSequence.SetLoops(-1, LoopType.Restart);
    }

    private void KillActiveSequence() {
        if(activeSequence != null) {
            activeSequence.Kill();
        }

        transform.localScale = Vector3.one;
    }

    public void SetSelectable() {
        KillActiveSequence();
        spriteRenderer.color = Color.blue;
    }
}
