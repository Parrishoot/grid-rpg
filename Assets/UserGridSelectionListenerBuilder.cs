using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGridSelectionListenerBuilder : UserGridSelectionListenerBuilderBase<UserGridSelectionListener>
{
    public UserGridSelectionListenerBuilder(ISelectableIngester ingester) : base(ingester)
    {
    }

    public override UserGridSelectionListener Build()
    {
        return new UserGridSelectionListener(ingester, numTargets, exact, gridFilter);
    }
}
