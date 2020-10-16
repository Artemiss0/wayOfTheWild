using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public void TransitionScene(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
