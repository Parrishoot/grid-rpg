using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSelectionController: MonoBehaviour
{
    public CharacterManager characterManager;

    public abstract GridSpaceSelector GetSelectAllSelector(ISelectableIngester ingester, GridFilter gridFilter);

    public abstract GridSpaceSelector GetSelector(ISelectableIngester ingester, GridFilter gridFilter, int numTargets = 1);

    public abstract ISelectableFilter GetEnemyOccupantFilter();

    public abstract ISelectableFilter GetAllyOccupantFilter();
}
