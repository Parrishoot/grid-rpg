using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectable : CharacterSelectable
{
    public UITweener uiTweener;

    public override void Start() {
        this.selectionManager = SelectionManager.GetInstance();
        StateController = GetComponent<ISelectableStateController>();
    }

    public override void Select()
    {
        base.Select();
        uiTweener.Open();
    }

    protected override void Reset() {
        uiTweener.Close();
        base.Reset();
    }
}
