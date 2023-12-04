using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskButtons : MonoBehaviour
{
    [SerializeField] GameObject taskPrefab;
    [SerializeField] Transform taskTransform;
    [SerializeField] TaskManager taskManager;

    public void CreateNewTask()
    {
        taskManager.tasks.Add(taskPrefab);
        Instantiate(taskPrefab, taskTransform.transform);
        
    }
}
