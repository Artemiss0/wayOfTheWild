using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDrop : MonoBehaviour
{
    public AnimalAbilityNameEnum AbilityName;
    public string Description;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<PlayerAbilities>().AddNewAbility(AbilityName);
            Destroy(gameObject);
        }
    }
}
