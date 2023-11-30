using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    //all functionality of the buttons in this script and make a list in the gardenmanager
    //to store information about the flower that needs to change behind the scene/when the user is not inside the garden
    [SerializeField] Button button;
    [SerializeField] GardenManager gardenManager;
    [SerializeField] GameObject needsIcon;
    [SerializeField] private TMP_Text growthTimerUI;
    [SerializeField] GameObject growthTimerUIBlock;

    public bool hasCried = false;
    public bool isSunned = false;
    public bool isSeeded = false;
    public bool rewardIsDropped = false;

    int currentState;
    public Sprite state1;
    public Sprite state2;
    public Sprite state3;
    public Sprite state4;

    public Sprite needSeeds;
    public Sprite needWater;
    public Sprite needSun;

    public float growthTimer = 10;
    public float roundedGrowthTimer;

    // Start is called before the first frame update
    void Start()
    {
        growthTimer = 10;
        growthTimerUIBlock.SetActive(false);
        currentState = 1;
    }

    // Update is called once per frame
    void Update()
    {
        roundedGrowthTimer = Mathf.RoundToInt(growthTimer);

        if (isSeeded && hasCried && isSunned && currentState >= 3 && growthTimer <= 0)
        {
            currentState = 4;
            button.GetComponent<Image>().sprite = state4;
            growthTimerUIBlock.SetActive(false);
            rewardIsDropped = true;
        }
        else if (isSeeded && hasCried && isSunned && currentState >= 2)
        {
            growthTimerUIBlock.SetActive(true);
            growthTimer -= Time.deltaTime;
            growthTimerUI.text = roundedGrowthTimer.ToString();
            currentState = 3;
            button.GetComponent<Image>().sprite = state3;
        }
        else if (isSeeded)
        {
            currentState = 2;
            button.GetComponent<Image>().sprite = state2;
        }

        if (!isSeeded)
        {
            needsIcon.SetActive(true);
            needsIcon.GetComponent<Image>().sprite = needSeeds;
        }
        else if (!hasCried && isSeeded)
        {
            needsIcon.GetComponent<Image>().sprite = needWater;
        }
        else if (!isSunned && hasCried && isSeeded)
        {
            needsIcon.GetComponent<Image>().sprite = needSun;
        } else
        {
            needsIcon.SetActive(false);
        }
    }

    public void PlantSeed()
    {
        if (gardenManager.isHoldingSeeds)
        {
            isSeeded = true;
            //gardenManager.hasSeeds = false;
        }
    }

    public void GiveWater()
    {
        if (gardenManager.isHoldingWater && isSeeded)
        {
            hasCried = true;
            //gardenManager.hasWater = false;
        }
    }

    public void GiveSun()
    {
        if (gardenManager.isHoldingSun && hasCried)
        {
            isSunned = true;
            //gardenManager.hasSun = false;
        }
    }

    public void CollectReward()
    {
        if(rewardIsDropped)
        {
            rewardIsDropped = false;
            isSeeded = false;
            hasCried = false;
            isSunned = false;
            growthTimer = 10;
            currentState = 1;
            button.GetComponent<Image>().sprite = state1;
        }
    }
}
