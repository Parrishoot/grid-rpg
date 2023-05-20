using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionSetController<T> : MonoBehaviour
where T: CharacterManager
{
    [SerializeField]
    public Action[] availableActions;

    public T characterManager;

    protected List<ActionController<T>> actionControllers;

    protected virtual void Start() {
        SetupControllers();
    }

    protected virtual void SetupControllers() {
        actionControllers = availableActions.Select(x => new ActionController<T>(x, characterManager)).ToList();
    }
}
