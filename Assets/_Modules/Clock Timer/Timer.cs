using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 0f; 
    [SerializeField] private float timeEnd = 60f; 

    void Update()
    {
        CountTime();
    }

    private void CountTime()
    {
        timer += Time.deltaTime;

        if (timer > timeEnd)
        {
            timer = timeEnd;
            SceneCtrlGameplay.Instance.sceneGameLose.SetActive(true);
            enabled = false;
        }

        string formattedTime = timer.ToString("F1");
        //Debug.Log(formattedTime);

        TextMeshProUGUI timerText = SceneCtrlGameplay.Instance.timerText;
        if (timerText != null)
        {
            timerText.text = formattedTime;
        }

    }
}
