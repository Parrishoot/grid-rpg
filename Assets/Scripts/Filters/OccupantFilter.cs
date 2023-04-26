using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupantFilter<T> : ISelectableFilter
where T : Selectable
{
    private bool isOccupied;

    public OccupantFilter(bool isOccupied = true) {
        this.isOccupied = isOccupied;
    }

    public bool Filter(GridSpaceSelectable gridSpace)
    {
        Transform occupantsParentTransform = gridSpace.Space.GetOccupantsParentTransform();

        if(isOccupied) {
            return occupantsParentTransform.GetComponentInChildren<T>() != null;
        }
        else {
            return occupantsParentTransform.GetComponentInChildren<T>() == null;
        }
    }
}
