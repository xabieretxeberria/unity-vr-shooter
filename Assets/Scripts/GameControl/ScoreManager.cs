using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int destroyedEnemies;
    private int score;

    private const int POINTS_PER_ENEMY = 100;

    [SerializeField]
    private Text destroyedEnemiesText;

    [SerializeField]
    private Text scoreText;

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

    public void AddDestroyedEnemy()
    {
        destroyedEnemies++;
        score += POINTS_PER_ENEMY;

        destroyedEnemiesText.text = destroyedEnemies.ToString();
        scoreText.text = score.ToString();
    }
}
