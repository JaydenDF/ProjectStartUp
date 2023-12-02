using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenButtons : MonoBehaviour
{
    [SerializeField] GardenManager gardenManager;

    public void SelectSeed()
    {
        if(gardenManager.seedAmount >= 1)
        {
            gardenManager.isHoldingSeeds = true;
            gardenManager.isHoldingWater = false;
            gardenManager.isHoldingSun = false;
        }
    }

    public void SelectWater()
    {
        if (gardenManager.waterAmount >= 1)
        {
            gardenManager.isHoldingWater = true;
            gardenManager.isHoldingSun = false;
            gardenManager.isHoldingSeeds = false;
        }
    }

    public void SelectSun()
    {
        if (gardenManager.sunAmount >= 1)
        {
            gardenManager.isHoldingSun = true;
            gardenManager.isHoldingWater = false;
            gardenManager.isHoldingSeeds = false;
        }
    }
}
