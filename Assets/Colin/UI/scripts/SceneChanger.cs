using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadSceneAsync("main");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
