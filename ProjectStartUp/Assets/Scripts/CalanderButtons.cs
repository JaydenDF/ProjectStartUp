using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalanderButtons : MonoBehaviour
{
    [SerializeField] CalanderDay calanderDay;
    [SerializeField] GameObject calanderDayButton;
    [SerializeField] CalanderManager calanderManager;

    public void AddEventToDay()
    {
        if (calanderManager.dayIsSelectd)
        {
            //change color of the button
            calanderDayButton.GetComponent<Image>().color = Color.red;
        }
    }

}
