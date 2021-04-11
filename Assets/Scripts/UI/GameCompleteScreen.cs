using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompleteScreen : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private float secondsToReplay;

    private float secondsToReplayCounter;

    [SerializeField]
    private Text replayText;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        secondsToReplayCounter = secondsToReplay;
        scoreText.text = $"Puntuación: {ScoreManager.instance.GetScore()}";
    }

    private void Update()
    {
        secondsToReplayCounter -= Time.deltaTime;

        if (secondsToReplayCounter < 0f) {
            //SceneLoader.instance.LoadMainMenu();
            SceneLoader.instance.LoadGameScene();
        }
    }

    private void OnGUI()
    {
        replayText.text = FormatTimeToReplay();
    }

    private string FormatTimeToReplay()
    {
        return $"Volviendo al menú en\n{Mathf.Min(secondsToReplay, secondsToReplayCounter + 1).ToString("0")}";
    }
}
