using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public abstract string GetDescription();

    public abstract GridFilter GetGridFilter(Vector2Int origin);

}
