using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestSO", menuName = "ScriptableObjects/Test/TestSO", order = 1)]
public class TestSO<T> : ScriptableObject
where T: CharacterManager
{
    public ActionController<T> GetActionController() {
        return new ActionController<T>();
    }
}
