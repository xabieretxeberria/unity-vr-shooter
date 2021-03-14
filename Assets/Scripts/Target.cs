using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private float loadTime;

    [SerializeField]
    private Image fillImage;

    private float loadTimeCounter;

    private bool loading;

    private void Update()
    {
        if (loading) {
            loadTimeCounter = Mathf.Min(loadTimeCounter + Time.deltaTime, loadTime);
        } else {
            loadTimeCounter = Mathf.Max(loadTimeCounter - Time.deltaTime, 0);
        }

        if (loadTimeCounter == loadTime) LoadComplete();
    }

    private void OnGUI()
    {
        fillImage.fillAmount = loadTimeCounter / loadTime;
    }

    public void StartLoading()
    {
        loading = true;
    }

    public void StopLoading()
    {
        loading = false;
    }

    private void LoadComplete()
    {
        StopLoading();

        fillImage.fillAmount = 0;
        loadTimeCounter = 0;

        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        enemy.Destroy();
    }
}
