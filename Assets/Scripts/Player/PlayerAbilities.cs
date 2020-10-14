using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public List<AnimalAbilityNameEnum> AbilitiesAquired;
    public AnimalAbilityNameEnum activeAbility { get; set; }

    public void AddNewAbility(AnimalAbilityNameEnum ability)
    {
        if (!AbilitiesAquired.Contains(ability))
        {
            AbilitiesAquired.Add(ability);
        }
    }
}
