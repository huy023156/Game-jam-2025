using TMPro;
using UnityEngine;

public class SceneCtrlGameplay : MonoBehaviour
{
    [SerializeField] private static SceneCtrlGameplay instance;
    public static SceneCtrlGameplay Instance => instance;

    [Header("Scene")]
    [SerializeField] private GameObject _sceneGame;
    public GameObject sceneGame => _sceneGame;

    [SerializeField] private GameObject _scenePause;
    public GameObject scenePause => _scenePause;

    [SerializeField] private GameObject _sceneGameLose;
    public GameObject sceneGameLose => _sceneGameLose;

    [SerializeField] private TextMeshProUGUI _timerText;
    public TextMeshProUGUI timerText => _timerText;

    private void Reset()
    {
        LoadComponent();
        LoadValue();
    }

    private void Awake()
    {
        LoadComponent();
        LoadValue();
    }

    private void LoadComponent()
    {
        LoadSceneCtrlGameplay();
        LoadSceneGame();
        LoadScenePause();
        LoadSceneEnd();
        LoadSceneCtrl();
    }

    private void LoadValue()
    {

    }

    private void LoadSceneCtrlGameplay()
    {
        if (SceneCtrlGameplay.instance != null) return;
        SceneCtrlGameplay.instance = this;
        Debug.Log(transform.name + ": Load GameCtrl", gameObject);
    }

    private void LoadSceneGame()
    {
        if (this._sceneGame != null) return;
        if (GameObject.Find("SceneGame") == null) return;
        if (GameObject.Find("SceneGame").transform.Find("ContentSG") == null) return;
        Transform childTransforms = GameObject.Find("SceneGame").transform.Find("ContentSG");
        if (childTransforms == null) return;
        this._sceneGame = childTransforms.gameObject;
        this._sceneGame.SetActive(true);
        Debug.Log(transform.name + ": Load SceneGame", gameObject);
    }

    private void LoadScenePause()
    {
        if (this._scenePause != null) return;
        if (GameObject.Find("ScenePause") == null) return;
        if (GameObject.Find("ScenePause").transform.Find("ContentPause") == null) return;
        Transform childTransforms = GameObject.Find("ScenePause").transform.Find("ContentPause");
        this._scenePause = childTransforms.gameObject;
        this._scenePause.SetActive(false);
        Debug.Log(transform.name + ": Load ScenePause", gameObject);
    }

    private void LoadSceneEnd()
    {
        if (this._sceneGameLose != null) return;
        if (GameObject.Find("SceneGameLose") == null) return;
        if (GameObject.Find("SceneGameLose").transform.Find("ContentSLG") == null) return;
        Transform childTransforms = GameObject.Find("SceneGameLose").transform.Find("ContentSLG");
        this._sceneGameLose = childTransforms.gameObject;
        this._sceneGameLose.SetActive(false);
        Debug.Log(transform.name + ": Load SceneGameLose", gameObject);
    }

    private void LoadSceneCtrl()
    {
        if (this._timerText != null) return;
        if (GameObject.Find("TimerText") == null) return;
        this._timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": Load TimerText", gameObject);
    }
}
