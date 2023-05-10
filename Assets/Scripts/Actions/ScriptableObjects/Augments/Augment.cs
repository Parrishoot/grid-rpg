using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: MERGE THIS CLASS WITH THE ABILITY CLASS JUST HAVE IT PROCESS ON THE CHARACTER AUTOMATICALLY
public abstract class Augment : ScriptableObject
{
    public abstract string GetDescription();

    public abstract void Apply(CharacterManager characterManager);

    public abstract void Remove(CharacterManager characterManager);
}
