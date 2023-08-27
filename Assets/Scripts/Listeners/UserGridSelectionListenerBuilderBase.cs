using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserGridSelectionListenerBuilderBase<T>: GridSpaceSelectorBuilder<T, UserGridSelectionListenerBuilderBase<T>>
where T: UserGridSelectionListener
{

    protected UserGridSelectionListenerBuilderBase(SelectableIngester ingester) : base(ingester)
    {

    }
}
