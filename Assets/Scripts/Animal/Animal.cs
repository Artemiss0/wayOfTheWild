using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public GameObject AbilityPrefab;
    protected string AbilityPath = "ScriptableObjects/Animal/Ability/";
    public abstract void DropAbility();
}
