using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDrop : MonoBehaviour
{
    public AnimalAbility AnimalAbility;
    public AnimalAbilityNameEnum AbilityName;
    public string Description;

    private void Start()
    {
        AbilityName = AnimalAbility.AbilityFromAnimal;
        Description = AnimalAbility.Description;
    }
}
