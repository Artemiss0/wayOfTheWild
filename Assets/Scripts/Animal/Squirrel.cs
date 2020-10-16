using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Animal
{
    public override void DropAbility()
    {
        Instantiate(AbilityPrefab, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z + 2), Quaternion.identity);
        AnimalAbility squirrel = (AnimalAbility) Resources.Load(AbilityPath + AnimalAbilityNameEnum.Squirrel);
        AbilityPrefab.GetComponent<AbilityDrop>().AbilityName = squirrel.AbilityFromAnimal;
        AbilityPrefab.GetComponent<AbilityDrop>().Description = squirrel.Description;
    }
}
