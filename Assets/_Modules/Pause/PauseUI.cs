using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour {
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button selectLevelButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject pausePanel;

    private bool isPaused;

    private void Start() {
        pauseButton.onClick.AddListener(() => {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        });

        homeButton.onClick.AddListener(() =>  Loader.Instance.LoadWithFade(SceneName.MainMenuScene));
        selectLevelButton.onClick.AddListener(() => Loader.Instance.LoadWithFade(SceneName.SelectLevelScene));
        resumeButton.onClick.AddListener(() => {
            Resume();
        });

        pausePanel.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Pause() {
        isPaused = true;
        PauseController.Instance.Pause();
        pausePanel.SetActive(true);
    }

    private void Resume() {
        isPaused = false;
        PauseController.Instance.Resume();
        pausePanel.SetActive(false);
    }
}
