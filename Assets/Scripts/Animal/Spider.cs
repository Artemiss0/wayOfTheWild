using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Animal
{
    public override void DropAbility()
    {
        Instantiate(AbilityPrefab, transform.position + transform.forward * 2, Quaternion.identity);
        AnimalAbility spider = (AnimalAbility)Resources.Load(AbilityPath + AnimalAbilityNameEnum.Spider);
        AbilityPrefab.GetComponent<AbilityDrop>().AbilityName = spider.AbilityFromAnimal;
        AbilityPrefab.GetComponent<AbilityDrop>().Description = spider.Description;
    }
}
