using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtons : MonoBehaviour
{
    [SerializeField] Timer timer;

    public void Add10Minutes(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.minutesTens += 1;
            }
        }
        else if (!isForMain)
        {
            if (timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakMinutesTens += 1;
            }
        }
    }

    public void Add1Minute(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.minutes += 1;
            }
        }
        else if (!isForMain)
        {
            if (timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakMinutes += 1;
            }
        }
    }

    public void Add10Seconds(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.secondsTens < 10 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.secondsTens += 1;
            }
            else if (timer.secondsTens >= 10 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.minutes += 1;
                timer.secondsTens = 0;
            }
        }
        else if (!isForMain)
        {
            if (timer.breakSecondsTens < 10 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakSecondsTens += 1;
            }
            else if (timer.breakSecondsTens >= 10 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakMinutes += 1;
                timer.breakSecondsTens = 0;
            }
        }
    }

    public void Add1Second(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.seconds += 1;
            }
            else if (timer.seconds >= 60 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.minutes += 1;
                timer.seconds = 0;
            }
        }
        else if (!isForMain)
        {
            if (timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakSeconds += 1;
            }
            else if (timer.seconds >= 60 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakMinutes += 1;
                timer.breakSeconds = 0;
            }
        }
    }

    public void Dec10Minutes(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.minutesTens >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.minutesTens -= 1;
            }
        }
        else if (!isForMain)
        {
            if (timer.breakMinutesTens >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakMinutesTens -= 1;
            }
        }
    }
    public void Dec1Minute(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.minutes >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.minutes -= 1;
            }
        }
        else if (!isForMain)
        {
            if (timer.breakMinutes >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakMinutes -= 1;
            }
        }
    }
    public void Dec10Seconds(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.secondsTens >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.secondsTens -= 1;
            }
        }
        else if (!isForMain)
        {
            if (timer.breakSecondsTens >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakSecondsTens -= 1;
            }
        }
    }
    public void Dec1second(bool isForMain)
    {
        if (isForMain)
        {
            if (timer.seconds >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.seconds -= 1;
            }
        }
        else if(!isForMain)
        {
            if (timer.breakSeconds >= 1 && timer.timerHasStarted == false && timer.breakTimerHasStarted == false)
            {
                timer.breakSeconds -= 1;
            }
        }
    }

    public void ChangeSessionAmmount(bool isIncreasing)
    {
        if (!timer.timerHasStarted && !timer.breakTimerHasStarted)
        {
            if (isIncreasing)
            {
                timer.sessionAmount++;
            }
            else if (!isIncreasing && timer.sessionAmount > 0)
            {
                timer.sessionAmount--;
            }
        }   
    }

    public void StartTimer()
    {
        timer.sessionAmount--;

        timer.timerHasStarted = true;
        timer.rememberMinutesTens = timer.minutesTens;
        timer.rememberMinutes = timer.minutes;
        timer.rememberSecondsTens = timer.secondsTens;
        timer.rememberSeconds = timer.seconds;

        timer.rememberBreakMinutesTens = timer.breakMinutesTens;
        timer.rememberBreakMinutes = timer.breakMinutes;
        timer.rememberBreakSecondsTens = timer.breakSecondsTens;
        timer.rememberBreakSeconds = timer.breakSeconds;
    }

    public void ResetTimer()
    {
        timer.minutesTens = 0;
        timer.minutes = 0;
        timer.secondsTens = 0;
        timer.seconds = 0;
        timer.timerHasStarted = false;
    }
}
