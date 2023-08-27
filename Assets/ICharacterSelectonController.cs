using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSelectionController: MonoBehaviour
{
    public CharacterManager characterManager;

    public abstract GridSpaceSelector GetSelectAllSelector(SelectableIngester ingester, GridFilter gridFilter);

    public abstract GridSpaceSelector GetSelector(SelectableIngester ingester, GridFilter gridFilter, int numTargets = 1, bool exact = true);

    public abstract ISelectableFilter GetEnemyOccupantFilter();

    public abstract ISelectableFilter GetAllyOccupantFilter();
}
