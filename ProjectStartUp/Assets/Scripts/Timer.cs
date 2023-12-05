using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    //ui
    [SerializeField] private TMP_Text focusMinutesTens;
    [SerializeField] private TMP_Text focusMinutes;
    [SerializeField] private TMP_Text focusSeconds;
    [SerializeField] private TMP_Text focusSecondsTens;

    [SerializeField] private TMP_Text breakTimerMinutesTens;
    [SerializeField] private TMP_Text breakTimerMinutes;
    [SerializeField] private TMP_Text breakTimerSecondsTens;
    [SerializeField] private TMP_Text breakTimerSeconds;

    [SerializeField] private TMP_Text sessionCounter;
    //UnityEngine.UI.Image panel;

    //color break blue
    Color breakBlue = new Color(0.4f, 0.8509f, 1);

    //color focus red
    Color focusRed = new Color(0.463f, 0.133f, 0.097f);

    //color main green
    Color mainGreen = new Color(0.392f, 0.643f, 0.349f);

    //main timer
    public float minutes;
    public float minutesTens;
    public float rememberMinutes;
    public float rememberMinutesTens;
    public float seconds;
    public float secondsTens;
    public float rememberSeconds;
    public float rememberSecondsTens;
    public int roundedSeconds;

    //break timer
    public float breakMinutes;
    public float breakMinutesTens;
    public float rememberBreakMinutes;
    public float rememberBreakMinutesTens;
    public float breakSeconds;
    public float breakSecondsTens;
    public float rememberBreakSeconds;
    public float rememberBreakSecondsTens;
    public int roundedBreakSeconds;

    //session variables
    public int sessionAmount;

    //timer bools
    public bool timerHasStarted = false;
    public bool breakTimerHasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        //panel = GameObject.Find("BackgroundPanel").GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        roundedSeconds = Mathf.RoundToInt(seconds);
        roundedBreakSeconds = Mathf.RoundToInt(breakSeconds);

        //focusTimer.text = minutes + ":" + roundedSeconds;
        focusMinutesTens.text = minutesTens.ToString();
        focusMinutes.text = minutes.ToString();
        focusSecondsTens.text = secondsTens.ToString();
        focusSeconds.text = roundedSeconds.ToString();

        //breakTimer.text = breakMinutes + ":" + roundedBreakSeconds;
        breakTimerMinutesTens.text = breakMinutesTens.ToString();
        breakTimerMinutes.text = breakMinutes.ToString();
        breakTimerSecondsTens.text = breakSecondsTens.ToString();
        breakTimerSeconds.text = roundedBreakSeconds.ToString();

        sessionCounter.text = sessionAmount.ToString();

        if (timerHasStarted)
        {
            //panel.color = focusRed;
            breakMinutesTens = rememberBreakMinutesTens;
            breakMinutes = rememberBreakMinutes;
            breakSecondsTens = rememberBreakSecondsTens;
            breakSeconds = rememberBreakSeconds;

            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
            }
            else if (seconds <= 0 && secondsTens <= 0 && minutes <= 0 && minutesTens <= 0)
            {
                timerHasStarted = false;
                if (sessionAmount > 0)
                {
                    breakTimerHasStarted = true;
                }
            }
            else if (seconds <= 0 && secondsTens <= 0 && minutes <= 0 && minutesTens >= 1)
            {
                minutesTens--;
                minutes = 9;
                secondsTens = 5;
                seconds = 9;
            }
            else if (seconds <= 0 && secondsTens <= 0 && minutes >= 1)
            {
                minutes--;
                secondsTens = 5;
                seconds = 9;
            }
            else if (seconds <= 0 && secondsTens >= 1)
            {
                secondsTens--;
                seconds = 9;
            }
        }
        else if (breakTimerHasStarted && sessionAmount > 0)
        {
            //panel.color = breakBlue;
            minutesTens = rememberMinutesTens;
            minutes = rememberMinutes;
            secondsTens = rememberSecondsTens;
            seconds = rememberSeconds;

            if (breakSeconds > 0)
            {
                breakSeconds -= Time.deltaTime;
            }
            else if (breakSeconds <= 0 && breakMinutes <= 0 && breakSecondsTens <= 0 && breakMinutesTens <= 0 && sessionAmount > 0)
            {
                sessionAmount--;
                timerHasStarted = true;
                breakTimerHasStarted = false;
            }
            else if (sessionAmount <= 0)
            {
                minutes = rememberMinutes;
                seconds = rememberSeconds;
                timerHasStarted = false;
                breakTimerHasStarted = false;
            }
            else if (breakSeconds <= 0 && breakSecondsTens <= 0 && breakMinutes <= 0 && breakMinutesTens >= 1)
            {
                breakMinutesTens--;
                breakMinutes = 9;
                breakSecondsTens = 5;
                breakSeconds = 9;
            }
            else if (breakSeconds <= 0 && breakSecondsTens <= 0 && breakMinutes >= 1)
            {
                breakMinutes--;
                breakSecondsTens = 5;
                breakSeconds = 9;

            }
            else if (breakSeconds <= 0 && breakSecondsTens >= 1)
            {
                breakSecondsTens--;
                breakSeconds = 9;
            }
        }
        else if (!timerHasStarted && !breakTimerHasStarted && sessionAmount <= 0)
        {
            //panel.color = mainGreen;
        }
    }
}
