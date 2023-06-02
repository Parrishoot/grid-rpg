using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager
{

    public delegate void OnEvent(); 
    OnEvent onEvent;

    public void AddOnEvent(OnEvent onEventDelegate) {

        // Ensure there is only one of these events happening
        RemoveOnEvent(onEventDelegate);

        onEvent += onEventDelegate;
    }

    public void RemoveOnEvent(OnEvent onEventDelegate) {
        onEvent -= onEventDelegate;
    }

    public System.Delegate[] GetEventList() {
        return onEvent.GetInvocationList();
    }

    public void Clear() {
        onEvent = null;
    }

    public void Invoke() {
        onEvent?.Invoke();
    }
}
