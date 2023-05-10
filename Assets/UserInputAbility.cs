using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserInputAbility: SelectionAbility
{

    protected override GridSpaceSelector GetSpaceSelector(CharacterManager characterManager) {
        return new GridSelectionListenerBuilder(GetIngester(characterManager)).WithFilter(GetFilter(characterManager)).Build();
    }

    public override abstract string GetDescription();

    protected override abstract GridFilter GetFilter(CharacterManager characterManager);

    protected override abstract ISelectableIngester GetIngester(CharacterManager characterManager);

    public override void Remove(CharacterManager characterManager)
    {
        
    }
}
