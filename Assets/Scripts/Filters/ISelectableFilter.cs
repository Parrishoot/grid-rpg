using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectableFilter
{
    bool Filter(GridSpaceSelectable gridSpace);
}
