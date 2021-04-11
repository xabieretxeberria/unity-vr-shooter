using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public delegate void gameStart();
    public event gameStart gameStartReleased;

    public delegate void gameFailed();
    public event gameFailed gameFailedReleased;

    public delegate void gameComplete();
    public event gameComplete gameCompleteReleased;

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        StartGame();
    }

    private void Singleton()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if (gameStartReleased == null) return;

        gameStartReleased();
    }

    public void GameFailed()
    {
        if (gameFailedReleased == null) return;

        gameFailedReleased();
    }

    public void GameComplete()
    {
        if (gameCompleteReleased == null) return;

        gameCompleteReleased();
    }
}
