using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserInputAbility: SelectionAbility
{

    private UserGridSelectionListener userGridSelectionListener;

    protected override GridSpaceSelector GetSpaceSelector(CharacterManager characterManager) {

        // TODO: Maybe change this to typed generics
        // once I figured out how to get it to serialize
        // with Unity's goddamn inspector...  
        PlayerCharacterManager playerCharacterManager = (PlayerCharacterManager) characterManager;

        userGridSelectionListener = new UserGridSelectionListenerBuilder(GetIngester(characterManager), playerCharacterManager.SelectionController).WithFilter(GetFilter(characterManager)).Build();

        return userGridSelectionListener;
    }

    public override abstract string GetDescription();

    protected override abstract GridFilter GetFilter(CharacterManager characterManager);

    protected override abstract ISelectableIngester GetIngester(CharacterManager characterManager);

    public override void Remove(CharacterManager characterManager)
    {
        
    }
}
