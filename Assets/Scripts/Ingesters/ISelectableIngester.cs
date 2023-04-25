using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectableIngester
{
    void ProcessSelections(List<GridSpaceSelectable> selections);
}
