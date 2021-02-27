using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //public static TimeManager instance;

    public const int SECONDS_TO_SURVIVE = 60;

    private float remainingTimeCounter;
    private bool isActive;

    [SerializeField]
    private Text remainingTimeText;

    private void Awake()
    {
        //Singleton();
    }

    void Start()
    {
        remainingTimeCounter = SECONDS_TO_SURVIVE;
        isActive = true;
    }

    void Update()
    {
        if (!isActive) return;

        remainingTimeCounter -= Time.deltaTime;

        if (remainingTimeCounter < 0f) {
            remainingTimeCounter = 0f;
            isActive = false;
        }
    }

    private void OnGUI()
    {
        remainingTimeText.text = FormatRemainingTime();
    }

    private void Singleton()
    {
        //if (instance == null) {
        //    instance = this;
        //} else if (instance != this) {
        //    Destroy(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);
    }

    private string FormatRemainingTime()
    {
        return remainingTimeCounter.ToString("F0");
    }
}
