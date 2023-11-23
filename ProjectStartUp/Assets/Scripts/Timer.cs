using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text focusTimer;

    public float minutes = 5;
    public float seconds;
    public int roundedSeconds;

    public bool timerHasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundedSeconds = Mathf.RoundToInt(seconds);
        focusTimer.text = minutes + ":" + roundedSeconds;

        if (timerHasStarted)
        {
            if (seconds < 1)
            {
                seconds = 59;
                minutes--;
            }
            if (seconds > 0)
            {
                seconds = seconds - Time.deltaTime;
            }

            if(seconds <=0 && minutes <= 0)
            {
                timerHasStarted = false;
            }
        }
    }
}
