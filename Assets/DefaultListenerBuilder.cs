using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultListenerBuilder : SelectableListenerBuilderBase<DefaultListener>
{
    public DefaultListenerBuilder() : base(null)
    {
    }

    public override DefaultListener Build()
    {
        return new DefaultListener(ingester, numTargets, exact, gridFilter);
    }
}
