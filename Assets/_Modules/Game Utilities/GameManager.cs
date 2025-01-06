using UnityEngine;

public class GameManager : Singleton<GameManager> {
    [SerializeField] private float levelTimeMax;

    private void Start() {
        //AudioManager.Instance.PlayMusic(GameAudioClip.BGM_PLAYING, -10f);
    }

    private void Update() {
        // for testing
        if (Input.GetKeyDown(KeyCode.Space)) {
            AudioManager.Instance.PlaySound(GameAudioClip.POP);
        }
    }
}
