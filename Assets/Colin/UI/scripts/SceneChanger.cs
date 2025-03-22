using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("TimerScene");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
