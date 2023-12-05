using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskButtons : MonoBehaviour
{
    [SerializeField] GameObject taskPrefab;
    [SerializeField] RectTransform taskTransform;
    [SerializeField] TaskManager taskManager;

    public void CreateNewTask()
    {
        if(taskManager.taskAmount <= 2)
        {
            //add task
        }

        //amountOfTasks = taskManager.tasks.Count + 1;
        //taskManager.tasks.Add(taskPrefab);
        //Instantiate(taskPrefab, taskTransform.transform);
        //taskPrefab.transform.position = new Vector2(0, -(amountOfTasks * 100));

    }
}
