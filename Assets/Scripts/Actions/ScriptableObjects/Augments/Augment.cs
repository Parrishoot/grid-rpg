using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Augment : ScriptableObject
{
    public abstract string GetDescription();

    public abstract void Apply(CharacterManager characterManager);

    public abstract void Remove(CharacterManager characterManager);
}
