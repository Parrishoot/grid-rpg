using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageAbility", menuName = "ScriptableObjects/Abilities/Multi Target Damage Ability", order = 1)]
public class MultiTargetDamageAbility : DamageAbility
{
    public int numTargets;

    public override string GetDescription()
    {
        string enemyText = numTargets >= 1 ? "Enemies" : "Enemy";
        string rangeText = range >= 1 ? "Spaces" : "Space";

        return string.Format("Damage {0} {1} For {2} Damage Up To {3} {4} Away", numTargets, enemyText, power, range, rangeText);
    }

    protected override GridSpaceSelector GetSpaceSelector(CharacterManager characterManager) {
        return new GridSelectionListenerBuilder(GetIngester(characterManager)).WithFilter(GetFilter(characterManager))
                                                                              .WithNumTargets(numTargets)
                                                                              .Build();
    }
}
