using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused = false;


    public void PauseGame(InputAction.CallbackContext context) {
        if (isPaused == false) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        } else {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void ResumeGame() {
        if (isPaused == true) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
