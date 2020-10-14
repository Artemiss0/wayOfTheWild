using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal Ability", menuName = "AnimalAbilities")]
public class AnimalAbility : ScriptableObject
{
    public AnimalAbilityNameEnum AbilityFromAnimal;
    public string Description;
}

