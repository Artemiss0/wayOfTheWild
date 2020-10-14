using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    public int PlayerInteractionDistance = 5;
    private GameObject _currentHighlightedObject;

    // Update is called once per frame
    private void Update()
    {
        PlayerInteraction();
    }

    private void PlayerInteraction()
    {
        RaycastHit interactDetector;
        if(Physics.Raycast(transform.position, transform.forward, out interactDetector, PlayerInteractionDistance))
        {
            if (interactDetector.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                // For interaction
                _currentHighlightedObject = interactDetector.transform.gameObject;
                SetInteractionHighlight(_currentHighlightedObject, Shader.Find("Outlined/Highlight"));

            }  else if (interactDetector.transform.gameObject.layer == LayerMask.NameToLayer("Animal"))
            {
                // For animal interaction
                _currentHighlightedObject = interactDetector.transform.gameObject;
                SetInteractionHighlight(_currentHighlightedObject, Shader.Find("Outlined/Highlight"));

                InteractWithAnimal();
            }
        }
        else if(_currentHighlightedObject)
        {
            SetInteractionHighlight(_currentHighlightedObject, Shader.Find("Standard"));
        }
    }

    private void InteractWithAnimal()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Animal highlightedAnimal = _currentHighlightedObject.gameObject.GetComponent(typeof(Animal)) as Animal;
            print(highlightedAnimal);
            highlightedAnimal.DropAbility();
        }
    }

    private void SetInteractionHighlight(GameObject highlightedObject, Shader shader)
    {
        highlightedObject.GetComponent<Renderer>().material.shader = shader;
    }
}
