using UnityEngine;

public class Door : MonoBehaviour
{
    public string LeverlName;
    private SceneTransition _sceneTransition;

    private void Awake()
    {
        _sceneTransition = FindObjectOfType<SceneTransition>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _sceneTransition.TransitionScene(LeverlName);
    }
}
