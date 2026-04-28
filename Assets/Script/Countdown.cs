using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    public float countdownTime = 180f;
    private bool active = true;
    public GameObject endPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       if (!active) return;
       countdownTime -= Time.deltaTime;

        UpdateTimerUI();

        if (countdownTime <= 0)
        {
            StopTimer();
        }
    }

    public void StopTimer()
    { 
        active = false;
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        if (countdownTime > 0 && countdownTime < 60)
        {
            countdownText.color = Color.yellow;
        }
        else if (countdownTime < 5)
        {
            countdownText.color = Color.red;
        }
        if (countdownTime <= 0)
        {
            countdownTime = 0f;
            endPanel.SetActive(true);

        }
        TimeSpan t = TimeSpan.FromSeconds(countdownTime);
        countdownText.text = t.ToString(@"mm\:ss");
    }
}
