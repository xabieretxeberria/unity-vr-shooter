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

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        secondsToRetryCounter = secondsToRetry;
    }

    private void Update()
    {
        secondsToRetryCounter -= Time.deltaTime;

        if (secondsToRetryCounter < 0f) {
            SceneLoader.instance.LoadGameScene();
        }
    }

    private void OnGUI()
    {
        retryText.text = FormatTimeToRetry();
    }

    private string FormatTimeToRetry()
    {
        return $"Reiniciando en\n{Mathf.Min(secondsToRetry, secondsToRetryCounter + 1).ToString("0")}";
    }
}
