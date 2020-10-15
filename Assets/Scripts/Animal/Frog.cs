using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Animal
{
    public override void DropAbility()
    {
        Instantiate(AbilityPrefab, transform.position + transform.forward * 2, Quaternion.identity);
        AnimalAbility frog = (AnimalAbility)Resources.Load(AbilityPath + AnimalAbilityNameEnum.Frog);
        AbilityPrefab.GetComponent<AbilityDrop>().AbilityName = frog.AbilityFromAnimal;
        AbilityPrefab.GetComponent<AbilityDrop>().Description = frog.Description;
    }
}
