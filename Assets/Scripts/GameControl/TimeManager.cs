using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public const int SECONDS_TO_SURVIVE = 10;

    private float remainingTimeCounter;
    private bool isActive;

    [SerializeField]
    private Text remainingTimeText;

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

            GameController.instance.GameComplete();
        }
    }

    private void OnGUI()
    {
        remainingTimeText.text = FormatRemainingTime();
    }

    private string FormatRemainingTime()
    {
        return remainingTimeCounter.ToString("00.00");
    }
}
