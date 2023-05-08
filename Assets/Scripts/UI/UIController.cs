using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I would love to use an interface here, but this is to get around Unity's Serialization
public abstract class UIController: MonoBehaviour
{
    public abstract void Open();

    public abstract void Close();
}
