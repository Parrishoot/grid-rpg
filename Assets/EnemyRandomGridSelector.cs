using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGridSelector : GridSpaceSelector
{

    public EnemyRandomGridSelector(SelectableIngester ingester, GridFilter gridFilter, int numSelections = 1, bool exact = true) : base(ingester, gridFilter, numSelections, exact)
    {

    }

    public override void GatherSelections()
    {

        List<GridSpaceSelectable> selections = GetSelectableSpaces();

        if(selections.Count <= numSelections && exact) {
            ingester.AddSelections(selections);
            ProcessSelections();
            return;
        }

        int selected = 0;

        while((selected < numSelections && exact) || (selected == 0 && !exact)) {
            GridSpaceSelectable selection = selections[Random.Range(0, selections.Count - 1)];

            if(!ingester.GetSelections().Contains(selection)) {
                ingester.AddSelection(selection);
                selected++;
            }
        }

        ingester.ProcessSelections();
    }
}
