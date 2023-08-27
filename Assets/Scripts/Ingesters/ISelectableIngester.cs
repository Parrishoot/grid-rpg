using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class SelectableIngester
{

    public DelegateManager OnIngestionFinished { get; set; } = new DelegateManager();

    protected Stack<GridSpaceSelectable> selections = new Stack<GridSpaceSelectable>();

    public abstract void ProcessSelections();

    public virtual void ProcessPostIngestion() {
        OnIngestionFinished.Invoke();
    }

    public virtual GridSpaceSelectable RemoveSelection() {
        return selections.Pop();
    }

    public virtual void AddSelection(GridSpaceSelectable selection) {
        selections.Push(selection);
    }

    public virtual void AddSelections(List<GridSpaceSelectable> selections) {
        foreach(GridSpaceSelectable selection in selections) {
            AddSelection(selection);
        }
    }

    public List<GridSpaceSelectable> GetSelections() {
        return selections.ToList();
    }
}
