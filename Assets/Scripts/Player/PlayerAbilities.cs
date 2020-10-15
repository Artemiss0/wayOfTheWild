using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public List<AnimalAbilityNameEnum> AbilitiesAquired;
    public AnimalAbilityNameEnum ActiveAbility { get; set; }

    public Text ActiveAbilityText;

    private void Awake()
    {
        ActiveAbilityText.text = "Active ability: None";
    }

    private void Update()
    {
        ChangeActiveAbility();
    }

    public void AddNewAbility(AnimalAbilityNameEnum ability)
    {
        if (!AbilitiesAquired.Contains(ability))
        {
            AbilitiesAquired.Add(ability);
        }
    }

    private void ChangeActiveAbility()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) 
            && IsAbilityAquired(AnimalAbilityNameEnum.Squirrel))
        {
            ActiveAbility = AnimalAbilityNameEnum.Squirrel;
            ActiveAbilityText.text = "Active ability: Squirrel";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)
            && IsAbilityAquired(AnimalAbilityNameEnum.Frog))
        {
            ActiveAbility = AnimalAbilityNameEnum.Frog;
            ActiveAbilityText.text = "Active ability: Frog";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)
            && IsAbilityAquired(AnimalAbilityNameEnum.Spider))
        {
            ActiveAbility = AnimalAbilityNameEnum.Spider;
            ActiveAbilityText.text = "Active ability: Spider";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ActiveAbility = AnimalAbilityNameEnum.None;
            ActiveAbilityText.text = "Active ability: None";
        }
    }

    private bool IsAbilityAquired(AnimalAbilityNameEnum ability)
    {
        return AbilitiesAquired.Contains(ability);
    }
}
