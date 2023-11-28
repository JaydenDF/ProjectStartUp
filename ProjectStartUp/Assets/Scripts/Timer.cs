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
    [SerializeField] private TMP_Text focusTimer;
    [SerializeField] private TMP_Text breakTimer;
    [SerializeField] private TMP_Text sessionCounter;
    UnityEngine.UI.Image panel;
    int alphaColor = 1;

    //color break blue
    Color breakBlue = new Color(0.4f, 0.8509f, 1);

    //color focus red
    Color focusRed = new Color(0.463f, 0.133f, 0.097f);

    //color main green
    Color mainGreen = new Color(0.392f, 0.643f, 0.349f);

    //main timer
    public float minutes;
    public float rememberMinutes;
    public float seconds;
    public float rememberSeconds;
    public int roundedSeconds;

    //break timer
    public float breakMinutes;
    public float rememberBreakMinutes;
    public float breakSeconds;
    public float rememberBreakSeconds;
    public int roundedBreakSeconds;

    //session variables
    public int sessionAmount;

    //timer bools
    public bool timerHasStarted = false;
    public bool breakTimerHasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("BackgroundPanel").GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        roundedSeconds = Mathf.RoundToInt(seconds);
        roundedBreakSeconds = Mathf.RoundToInt(breakSeconds);
        focusTimer.text = minutes + ":" + roundedSeconds;
        breakTimer.text = breakMinutes + ":" + roundedBreakSeconds;
        sessionCounter.text = "Sessions: " + sessionAmount;

        if(timerHasStarted )
        {
            panel.color = focusRed;
            breakMinutes = rememberBreakMinutes; 
            breakSeconds = rememberBreakSeconds;

            if(seconds > 0) 
            {
                seconds -= Time.deltaTime;
            } 
            else if(seconds <= 0 && minutes >= 1)
            {
                minutes--;
                seconds = 59;
            }else if(seconds <= 0 && minutes <= 0)
            {
                timerHasStarted = false;
                if(sessionAmount > 0)
                {
                    breakTimerHasStarted = true;
                }
            }
        } 
        else if(breakTimerHasStarted && sessionAmount > 0)
        {
            panel.color = breakBlue;
            minutes = rememberMinutes;
            seconds = rememberSeconds;

            if (breakSeconds > 0)
            {
                breakSeconds -= Time.deltaTime;
            }
            else if (breakSeconds <= 0 && breakMinutes >= 1)
            {
                breakMinutes--;
                breakSeconds = 59;
            }
            else if (breakSeconds <= 0 && breakMinutes <= 0 && sessionAmount > 0)
            {
                sessionAmount--;
                timerHasStarted = true;
                breakTimerHasStarted = false;
            }
            else if(sessionAmount <=0)
            {
                minutes = rememberMinutes;
                seconds = rememberSeconds;
                timerHasStarted = false;
                breakTimerHasStarted = false;
            }
        }
        else if(!timerHasStarted && !breakTimerHasStarted && sessionAmount <= 0)
        {
            panel.color = mainGreen;
        }
    }
}
