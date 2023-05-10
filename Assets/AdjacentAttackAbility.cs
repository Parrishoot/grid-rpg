using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShockWaveDamageAbility", menuName = "ScriptableObjects/Abilities/Shockwave Damage Ability", order = 1)]
public class ShockwaveAttackAbility : DamageAbility
{
    public override string GetDescription()
    {
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Damage All Enemies Up To {1} {2} Away For {0} Damage ", power, range, rangeText);
    }

    protected override GridSpaceSelector GetSpaceSelector(CharacterManager characterManager) {
        return new GridAutoSelectorBuilder(GetIngester(characterManager)).WithFilter(GetFilter(characterManager))
                                                                         .Build();
    }
}
