using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectable : FocusSelectable
{
    public UITweener uiTweener;

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
