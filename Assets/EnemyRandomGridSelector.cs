using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGridSelector : GridSpaceSelector
{
    private int numSelections;

    public EnemyRandomGridSelector(ISelectableIngester ingester, GridFilter gridFilter, int numSelections = 1) : base(ingester, gridFilter)
    {
        this.numSelections = numSelections;
    }

    public override void GatherSelections()
    {

        List<GridSpaceSelectable> selections = GetSelectableSpaces();

        if(selections.Count <= numSelections) {
            ProcessSelections(selections);
            return;
        }

        List<GridSpaceSelectable> randomSelections = new List<GridSpaceSelectable>(); 

        while(randomSelections.Count < numSelections) {
            GridSpaceSelectable selection = selections[Random.Range(0, selections.Count - 1)];

            if(!randomSelections.Contains(selection)) {
                randomSelections.Add(selection);
            }
        }

        ingester.ProcessSelections(randomSelections);
    }
}
