using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSelectable : Selectable
{
    public override void Select()
    {
        base.Select();
        CameraController.GetInstance().SetTarget(gameObject);
    }
}
