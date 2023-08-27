using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserInputAbility: SelectionAbility
{
    protected override GridSpaceSelector GetSpaceSelector(CharacterManager characterManager) {
        return characterManager.SelectionController.GetSelector(GetIngester(characterManager), GetFilter(characterManager), GetNumberOfTargets(), GetExactSelection());
    }

    public override abstract string GetDescription();

    protected override abstract GridFilter GetFilter(CharacterManager characterManager);

    protected override abstract SelectableIngester GetIngester(CharacterManager characterManager);

    public override void Remove(CharacterManager characterManager)
    {
        
    }
}
