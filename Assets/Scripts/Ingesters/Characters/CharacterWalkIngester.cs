using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterWalkIngester : SelectableIngester
{
    protected GridMover gridMover;

    protected CharacterTurnController characterTurnController;

    protected WalkAbility walkAbility;

    protected PathTracker pathTracker;

    public CharacterWalkIngester(GridMover gridMover, WalkAbility currentWalkAbility, CharacterTurnController characterTurnController)
    {
        this.gridMover = gridMover;
        this.characterTurnController = characterTurnController;
        this.walkAbility = currentWalkAbility;
        this.pathTracker = gridMover.GetPathTracker();
    }

    public override void ProcessSelections()
    {
        List<Vector2Int> path = pathTracker.GetPath();
        gridMover.SetPath(path, ProcessPostIngestion);
    }

    public override void AddSelection(GridSpaceSelectable selection)
    {
        base.AddSelection(selection);

        Vector2Int startingLocation = pathTracker.GetPathDistance() != 0 ? pathTracker.GetPath().Last() : gridMover.CurrentGridPos;

        pathTracker.AddSegment(GridManager.GetInstance().FindPath(startingLocation, selection.Space.CellCoords));
    }

    public override GridSpaceSelectable RemoveSelection()
    {
        GridSpaceSelectable removed = base.RemoveSelection();
        pathTracker.RemoveSegment();

        return removed;
    }


}
