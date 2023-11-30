using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    //all functionality of the buttons in this script and make a list in the gardenmanager
    //to store information about the flower that needs to change behind the scene/when the user is not inside the garden
    [SerializeField] Button button;
    [SerializeField] GardenManager gardenManager;

    public bool hasCried = false;
    public bool isSunned = false;
    public bool isSeeded = false;
    public bool rewardIsDropped = false;

    int currentState;
    public Sprite state1;
    public Sprite state2;
    public Sprite state3;
    public Sprite state4;

    public float growthTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentState = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCried && isSunned && currentState >= 3 && growthTimer > 10)
        {
            currentState = 4;
            button.GetComponent<Image>().sprite = state4;
            rewardIsDropped = true;
        }
        else if (hasCried && isSunned && currentState >= 2)
        {
            growthTimer += Time.deltaTime;
            currentState = 3;
            button.GetComponent<Image>().sprite = state3;
        }
        else if (isSeeded)
        {
            currentState = 2;
            button.GetComponent<Image>().sprite = state2;
        }
    }

    public void PlantSeed()
    {
        if (gardenManager.isHoldingSeeds)
        {
            isSeeded = true;
            gardenManager.hasSeeds = false;
        }
    }

    public void GiveWater()
    {
        if (gardenManager.isHoldingWater)
        {
            hasCried = true;
            gardenManager.hasWater = false;
        }
    }

    public void GiveSun()
    {
        if (gardenManager.isHoldingSun)
        {
            isSunned = true;
            gardenManager.hasSun = false;
        }
    }

    public void CollectReward()
    {
        if(rewardIsDropped)
        {
            currentState = 1;
            button.GetComponent<Image>().sprite = state1;
        }
    }
}
