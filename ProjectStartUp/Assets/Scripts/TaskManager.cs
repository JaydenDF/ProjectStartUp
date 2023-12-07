using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class TaskManager : MonoBehaviour
{
    //Rigidbody2D rb;
    //public List<GameObject> tasks = new List<GameObject>();

    [SerializeField] private GardenManager gardenManager;

    public RectTransform firstTaskLocation;
    public RectTransform secondTaskLocation;
    public RectTransform thirdTaskLocation;

    public int taskAmount = 3;
    public bool hasHadThreeTasks = false;
    public bool dailyRewardAvailable;

    public bool justDeletedFirst;
    public bool justDeletedSecond;
    public bool justDeletedThird;

    public bool secondTaskMoved;
    public bool thirdTaskMoved;

    public bool newTaskCanBeCreated = true;

    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        dailyRewardAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(taskAmount < 3)
        {
            newTaskCanBeCreated = true;
        } 
        else
        {
            newTaskCanBeCreated = false;
        }

        if(hasHadThreeTasks && taskAmount == 0 && dailyRewardAvailable)
        {
            gardenManager.seedAmount++;
            dailyRewardAvailable = false;
        }
    }
}
