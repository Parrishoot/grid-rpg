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

        return string.Format("Damage {1} {2} For {3} Damage Up To {4} {5} Away", numTargets, enemyText, power, range, rangeText);
    }

    public override GridSelectionListener GetListener(CharacterManager characterManager)
    {
        return new SelectableListenerBuilder(GetIngester(characterManager)).WithFilter(GetFilter(characterManager)).WithNumTargets(numTargets).Build();
    }
}
