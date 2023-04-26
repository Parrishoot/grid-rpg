using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackIngester : MonoBehaviour, ISelectableIngester
{
    public int range = 2;

    public int damage = 5;

    public int numTargets = 2;

    public GridMover gridMover;

    public void BeginListening() {
        GridSelectionListener listener = new SelectableListenerBuilder(this).WithFilter(new RangeFilter(gridMover.currentGridPos, range, true))
                                                                            .WithFilter(new OccupantFilter<EnemySelectable>())
                                                                            .WithNumTargets(numTargets)
                                                                            .WithExactSelection(false)
                                                                            .Build();
        SelectionManager.GetInstance().AssignListener(listener);
    }

    public void ProcessSelections(List<GridSpaceSelectable> selections)
    {
        selections[0].Space.GetOccupantsParentTransform().GetComponentInChildren<EnemySelectable>().healthController.TakeDamage(damage);
        SelectionManager.GetInstance().EndListening();
    }
}
