using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISelectableIngester
{

    public DelegateManager OnIngestionFinished { get; set; } = new DelegateManager();

    public abstract void ProcessSelections(List<GridSpaceSelectable> selections);

    public virtual void ProcessPostIngestion() {
        OnIngestionFinished.Invoke();
    }
}
