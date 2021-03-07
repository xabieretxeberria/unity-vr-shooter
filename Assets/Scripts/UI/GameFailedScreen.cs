using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFailedScreen : MonoBehaviour
{
    [SerializeField]
    private float secondsToRetry;

    private float secondsToRetryCounter;

    [SerializeField]
    private Text retryText;

    public void OnEnable()
    {
        secondsToRetryCounter = secondsToRetry;
    }

    private void Update()
    {
        secondsToRetryCounter -= Time.deltaTime;

        if (secondsToRetryCounter < 0f) {
            SceneLoader.instance.ReloadGameScene();
        }
    }

    private void OnGUI()
    {
        retryText.text = FormatTimeToRetry();
    }

    private string FormatTimeToRetry()
    {
        return $"Reintentando en\n{Mathf.Min(secondsToRetry, secondsToRetryCounter + 1).ToString("0")}";
    }
}
