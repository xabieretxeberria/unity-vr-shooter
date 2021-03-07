using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private GameObject gameCompleteScreen;

    [SerializeField]
    private GameObject gameFailedScreen;

    public delegate void gameFailed();
    public event gameFailed gameFailedReleased;

    public delegate void gameComplete();
    public event gameComplete gameCompleteReleased;

    private void Awake()
    {
        Singleton();
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

    public void GameFailed()
    {
        if (gameFailedReleased == null) return;

        gameFailedReleased();

        gameFailedScreen.SetActive(true);
    }

    public void GameComplete()
    {
        if (gameCompleteReleased == null) return;

        gameCompleteReleased();

        gameCompleteScreen.SetActive(true);
    }
}
