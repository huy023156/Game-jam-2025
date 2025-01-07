using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGameUI : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject WinPanel;

    private ConfirmDialogue confirmDialog;
    private bool isLost;

    private void Awake()
    {
        nextButton.onClick.AddListener(OnNextLevelBtnClick);
        replayButton.onClick.AddListener(OnReplayBtnClick);
        homeButton.onClick.AddListener(OnHomeBtnClick);
        WinPanel.SetActive(false);
    }
    
    private async void OnNextLevelBtnClick()
    {
        confirmDialog = ConfirmDialogue.Create();
        bool result = await confirmDialog.Show();
        if (result)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    private async void OnReplayBtnClick()
    {
        confirmDialog = ConfirmDialogue.Create();
        bool result = await confirmDialog.Show();
        if (result)
        {
            Loader.Instance.LoadWithFade(SceneName.GameScene);
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
    
    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
    }
    
    public void HideWinPanel()
    {
        WinPanel.SetActive(false);
    }
    
    public void ShowConfirmDialogue(ConfirmDialogue confirmDialogue)
    {
        confirmDialog = confirmDialogue;
    }
    public void Start()
    {
        EventDispatcher.Add<EventDefine.OnWinGame>(OnWinGame);
    }
    private void OnDestroy()
    {
        EventDispatcher.Remove<EventDefine.OnWinGame>(OnWinGame);
    }
    private void OnWinGame(IEventParam param)
    {
        ShowWinPanel();
    }
}