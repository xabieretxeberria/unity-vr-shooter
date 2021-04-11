using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCanvas : MonoBehaviour
{
    [SerializeField]
    private GameCompleteScreen gameCompleteScreen;

    [SerializeField]
    private GameFailedScreen gameFailedScreen;

    private void OnEnable()
    {
        GameController.instance.gameStartReleased += OnGameStart;
        GameController.instance.gameFailedReleased += OnGameFailed;
        GameController.instance.gameCompleteReleased += OnGameComplete;
    }

    private void OnDisable()
    {
        GameController.instance.gameStartReleased -= OnGameStart;
        GameController.instance.gameFailedReleased -= OnGameFailed;
        GameController.instance.gameCompleteReleased -= OnGameComplete;
    }

    private void OnGameStart()
    {
        gameCompleteScreen.Hide();
        gameFailedScreen.Hide();
    }

    private void OnGameFailed()
    {
        gameFailedScreen.Show();
    }

    private void OnGameComplete()
    {
        gameCompleteScreen.Show();
    }
}
