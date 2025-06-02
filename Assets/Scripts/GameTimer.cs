using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [SerializeField] private float countdownTime = 60f;
    [SerializeField] private TextMeshProUGUI timerText;
    //private bool isTimerRunning = true;

    void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        float timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        timerText.text = "0";
        Time.timeScale = 0f; // Dừng toàn bộ game
        Debug.Log("Win");
    }
}
