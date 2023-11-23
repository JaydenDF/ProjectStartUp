using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtons : MonoBehaviour
{
    [SerializeField] Timer timer;

    public void Add5Minutes()
    {
        if(timer.timerHasStarted == false)
        {
            timer.minutes += 5;
        }
    }

    public void Add1Minute()
    {
        if (timer.timerHasStarted == false)
        {
            timer.minutes += 1;
        }
    }

    public void StartTimer()
    {
        timer.timerHasStarted = true;
    }

    public void ResetTimer()
    {
        timer.minutes = 0;
        timer.seconds = 0;
        timer.timerHasStarted = false;
    }
}
