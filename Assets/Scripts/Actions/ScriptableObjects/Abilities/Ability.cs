using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Ability: ScriptableObject
{
    public abstract string GetDescription();
 
    public abstract void Apply(CharacterManager characterManager);
 
    public abstract void Remove(CharacterManager characterManager);

    public virtual void Reset() {
        
    }
}
