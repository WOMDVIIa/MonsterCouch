using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void GoToScene(string sceneToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
