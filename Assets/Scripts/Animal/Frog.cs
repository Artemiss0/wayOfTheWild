using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Animal
{
    public override void DropAbility()
    {
        Instantiate(AbilityPrefab, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z + 2), Quaternion.identity);
        AnimalAbility frog = (AnimalAbility)Resources.Load(AbilityPath + AnimalAbilityNameEnum.Frog);
        AbilityPrefab.GetComponent<AbilityDrop>().AbilityName = frog.AbilityFromAnimal;
        AbilityPrefab.GetComponent<AbilityDrop>().Description = frog.Description;
    }
}
