using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseGameUI : MonoBehaviour
{
    [SerializeField] private Button replayButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject LosePanel;

    private ConfirmDialogue confirmDialog;
    private bool isLost;

    private void Awake()
    {
        replayButton.onClick.AddListener(OnReplayBtnClick);
        homeButton.onClick.AddListener(OnHomeBtnClick);

        LosePanel.SetActive(false);
    }

    private void Start()
    {
        // Đăng ký sự kiện OnLoseGame
        EventDispatcher.Add<EventDefine.OnLoseGame>(OnLoseGame);
    }

    private void OnDestroy()
    {
        // Hủy đăng ký sự kiện khi đối tượng bị hủy
        EventDispatcher.Remove<EventDefine.OnLoseGame>(OnLoseGame);
    }

    private async void OnReplayBtnClick()
    {
        confirmDialog = ConfirmDialogue.Create();
        bool result = await confirmDialog.Show();
        if (result)
        {
            Loader.Instance.LoadWithFade(SceneName.Level1);
        }
    }

    private async void OnHomeBtnClick()
    {
        confirmDialog = ConfirmDialogue.Create();
        bool result = await confirmDialog.Show();
        if (result)
        {
            Loader.Instance.LoadWithFade(SceneName.MainMenuScene);
        }
    }


    // Xử lý sự kiện OnLoseGame
    private void OnLoseGame(IEventParam param)
    {
        LosePanel.SetActive(true); // Hiển thị LosePanel
        Debug.Log("Game Over! LosePanel is now active.");
    }
}
