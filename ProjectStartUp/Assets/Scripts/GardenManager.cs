using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GardenManager : MonoBehaviour
{
    [SerializeField] private TMP_Text waterAmountUI;
    [SerializeField] private TMP_Text sunAmountUI;
    [SerializeField] private TMP_Text seededAmountUI;

    public int sunAmount = 6;
    public int waterAmount = 6;
    public int seedAmount = 6;

    public bool hasSun = true;
    public bool hasWater = true;
    public bool hasSeeds = true;

    public bool isHoldingSun = false;
    public bool isHoldingWater = false;
    public bool isHoldingSeeds = false;

    public bool hasSunnedPlant = false;
    public bool hasCriedYet = false;


    private void Awake()
    {
        sunAmount = 6;
        waterAmount = 6;
        seedAmount = 6;
    }
    // Update is called once per frame
    void Update()
    {
        waterAmountUI.text = "Water: " + waterAmount;
        sunAmountUI.text = "Sun: " + sunAmount;
        seededAmountUI.text = "seeds: " + seedAmount;
    }
}
