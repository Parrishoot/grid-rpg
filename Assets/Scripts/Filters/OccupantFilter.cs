using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupantFilter<T> : ISelectableFilter
where T : Selectable
{
    public bool Filter(GridSpaceSelectable gridSpace)
    {
        Transform occupantsParentTransform = gridSpace.Space.GetOccupantsParentTransform();
        return occupantsParentTransform.GetComponentInChildren<T>() != null;
    }
}
