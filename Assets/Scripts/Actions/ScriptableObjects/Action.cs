using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBasicAction", menuName = "ScriptableObjects/Actions/BasicAction", order = 1)]
public class Action : ScriptableObject
{
    public string actionName;

    public int cost = 10;
 
    [SerializeField]
    public Ability active;

    [SerializeField]
    public Ability passive;
}
