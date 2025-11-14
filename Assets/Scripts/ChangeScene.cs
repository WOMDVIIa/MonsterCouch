using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void GoToScene(string sceneToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
