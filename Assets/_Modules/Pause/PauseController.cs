using UnityEngine;

public static class PauseController {
    public static void Pause() {
        Time.timeScale = 0;
        EventDispatcher.Dispatch(new EventDefine.OnGamePaused { isPaused = true });
    }

    public static void Resume() {
        Time.timeScale = 1;
        EventDispatcher.Dispatch(new EventDefine.OnGamePaused { isPaused = false });
    }
}
