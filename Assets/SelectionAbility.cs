using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectionAbility : Ability
{

    protected abstract GridSpaceSelector GetSpaceSelector(CharacterManager characterManager);

    public override void Apply(CharacterManager characterManager) {
        GetSpaceSelector(characterManager).GatherSelections();
    }   
    
    protected abstract GridFilter GetFilter(CharacterManager characterManager);
 
    protected abstract SelectableIngester GetIngester(CharacterManager characterManager);

    protected virtual int GetNumberOfTargets() {
        return 1;
    }

    protected virtual bool GetExactSelection() {
        return true;
    }
}
