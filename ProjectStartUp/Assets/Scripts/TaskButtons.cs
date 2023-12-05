using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskButtons : MonoBehaviour
{
    [SerializeField] GameObject taskPrefab;
    [SerializeField] Task tasks;
    //[SerializeField] RectTransform taskTransform;
    [SerializeField] TaskManager taskManager;

    public void Awake()
    {
        tasks.taskPosition = 0;
    }

    public void CreateNewTask()
    {
        if(taskManager.newTaskCanBeCreated && taskManager.taskAmount < 3)
        {
            if(taskManager.taskAmount == 0)
            {
                Instantiate(taskPrefab, taskManager.firstTaskLocation);
                tasks.taskPosition = 1;
                Debug.Log("im 1");
            }
            else if(taskManager.taskAmount == 1)
            {
                Instantiate(taskPrefab, taskManager.secondTaskLocation);
                tasks.taskPosition = 2;
                Debug.Log("im 2");
            }
            else if(taskManager.taskAmount == 2)
            {
                Instantiate(taskPrefab, taskManager.thirdTaskLocation);
                tasks.taskPosition = 3;
                Debug.Log("im 3");
            }
        }

        taskManager.taskAmount++;

        //amountOfTasks = taskManager.tasks.Count + 1;
        //taskManager.tasks.Add(taskPrefab);
        //Instantiate(taskPrefab, taskTransform.transform);
        //taskPrefab.transform.position = new Vector2(0, -(amountOfTasks * 100));

    }
}
