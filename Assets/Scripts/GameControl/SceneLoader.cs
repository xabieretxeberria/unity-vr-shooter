using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    const int MAIN_MENU_SCENE_ID = 0;
    const int GAME_SCENE_ID = 1;

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

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_ID, LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_ID, LoadSceneMode.Single);
    }
}
