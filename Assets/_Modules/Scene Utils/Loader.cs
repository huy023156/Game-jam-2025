using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    MainMenuScene,
    SelectLevelScene,
    GameScene,
}

public class Loader : Singleton<Loader> 
{

    public void Load(SceneName targetScene)
    {
        EventDispatcher.Dispatch(new EventDefine.OnLoadScene());
        SceneManager.LoadSceneAsync(targetScene.ToString());
    }

    public void LoadWithFade(SceneName targetScene) {
        StartCoroutine(LoadWithFadeCoroutine(targetScene));
    }

    public IEnumerator LoadWithFadeCoroutine(SceneName targetScene)
    {
        Transform fadeTransitionPrefab = Resources.Load<Transform>("pfFadeSceneTransition");
        FadeTransition fadeTransition = Instantiate(fadeTransitionPrefab).GetComponent<FadeTransition>();
        DontDestroyOnLoad(fadeTransition.gameObject);

        yield return StartCoroutine(fadeTransition.FadeOut());
        Load(targetScene);
        yield return StartCoroutine(fadeTransition.FadeIn());
        Destroy(fadeTransition.gameObject);
    }
}
