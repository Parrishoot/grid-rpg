using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFilter
{
    private List<ISelectableFilter> filters = new List<ISelectableFilter>();

    public bool Evaluate(GridSpaceSelectable gridSpaceSelectable) {
        
        bool pass = true;
        
        foreach(ISelectableFilter filter in filters) {
            pass = pass && filter.Filter(gridSpaceSelectable);
            if(!pass) {
                return false;
            }
        }
        
        return true;
    }

    public void AddFilter(ISelectableFilter filter) {
        filters.Add(filter);
    }
}
