using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    // Hàm gọi khi nhấn nút Replay
    public void ReplayGame()
    {
        // Load lại Scene hiện tại
        AudioListener.pause = false;
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Hàm gọi khi nhấn nút Home
    public void GoToMainMenu()
    {
        // Load Scene Main Menu
        AudioListener.pause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
        
    }

    // Hàm gọi khi nhấn nút SelectLevelScene
    public void GoToSelectLevelScene()
    {
        // Load Scene SelectLevelScene
        AudioListener.pause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectLevelScene");
    }

    // Hàm gọi khi nhấn nút PauseScene
    public void PauseScene()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
        SceneCtrlGameplay.Instance.scenePause.SetActive(true);
    }

    // Hàm gọi khi nhấn nút RunScene
    public void RunScene()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        SceneCtrlGameplay.Instance.scenePause.SetActive(false);
    }
}
