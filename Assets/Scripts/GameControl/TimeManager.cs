using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public const int SECONDS_TO_SURVIVE = 60;

    private float remainingTimeCounter;
    private bool isActive;

    [SerializeField]
    private Text remainingTimeText;

    private void OnEnable()
    {
        GameController.instance.gameFailedReleased += OnGameFailed;
    }

    private void OnDisable()
    {
        GameController.instance.gameFailedReleased -= OnGameFailed;
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
            StopTimer();

            GameController.instance.GameComplete();
        }
    }

    private void OnGUI()
    {
        remainingTimeText.text = FormatRemainingTime();
    }

    private string FormatRemainingTime()
    {
        return Mathf.Min(SECONDS_TO_SURVIVE, remainingTimeCounter + 1).ToString("00");
    }

    private void StopTimer()
    {
        isActive = false;
    }

    private void OnGameFailed()
    {
        StopTimer();
    }
}
