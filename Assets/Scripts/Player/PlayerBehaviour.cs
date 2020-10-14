using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
                _currentHighlightedObject = interactDetector.transform.gameObject;
                SetInteractionHighlight(_currentHighlightedObject, Shader.Find("Outlined/Highlight"));
            } 
        }
        else if(_currentHighlightedObject)
        {
            SetInteractionHighlight(_currentHighlightedObject, Shader.Find("Standard"));
        }
    }

    private void SetInteractionHighlight(GameObject highlightedObject, Shader shader)
    {
        highlightedObject.GetComponent<Renderer>().material.shader = shader;
    }
}
