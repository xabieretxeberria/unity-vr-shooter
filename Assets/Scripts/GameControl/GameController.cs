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

    private void Awake()
    {
        Singleton();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
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
        Debug.Log("Game Failed");
    }

    public void GameComplete()
    {
        Debug.Log("Game Complete!");
    }
}
