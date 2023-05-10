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
 
    protected abstract ISelectableIngester GetIngester(CharacterManager characterManager);
}
