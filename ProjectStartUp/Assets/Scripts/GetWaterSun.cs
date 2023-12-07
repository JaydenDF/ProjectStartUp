using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWaterSun : MonoBehaviour
{
    [SerializeField] GardenManager gardenManager;
    [SerializeField] GameObject check;

    public bool canCompleteTaskToday;

    public void Awake()
    {
        canCompleteTaskToday = true;
    }

    public void CompleteTodaysTask()
    {
        if(canCompleteTaskToday)
        {
            gardenManager.waterAmount++;
            gardenManager.sunAmount++;
            canCompleteTaskToday = false;
            check.SetActive(true);
        }
    }
}
