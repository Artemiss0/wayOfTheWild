using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Animal
{
    public override void DropAbility()
    {
        Instantiate(AbilityPrefab, transform.position + transform.forward * 2, Quaternion.identity);
        AnimalAbility squirrel = (AnimalAbility) Resources.Load(AbilityPath + AnimalAbilityNameEnum.Squirrel);
        AbilityPrefab.GetComponent<AbilityDrop>().AbilityName = squirrel.AbilityFromAnimal;
        AbilityPrefab.GetComponent<AbilityDrop>().Description = squirrel.Description;
    }
}
