using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    //[SerializeField] GameObject taskPrefab;
    public int taskPosition;
    bool isStandardTask = false;


    // Start is called before the first frame update
    void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //code that continueasly updates the location of the tasks
        //needs to know wether it is first second third and if it was a standard task

        if(taskManager.justDeletedFirst && taskPosition > 0)
        {
            transform.position = taskManager.firstTaskLocation.transform.position;
            taskPosition--;
            taskManager.justDeletedFirst = false;
            taskManager.secondTaskMoved = true;
            taskManager.newTaskCanBeCreated = true;
        }
        else if((taskManager.justDeletedSecond || taskManager.secondTaskMoved) && taskPosition > 1)
        {
            transform.position = taskManager.secondTaskLocation.transform.position;
            taskPosition--;
            taskManager.secondTaskMoved = false;
            taskManager.justDeletedSecond = false;
            taskManager.thirdTaskMoved = true;
            taskManager.newTaskCanBeCreated = true;

        } else if (taskManager.justDeletedThird || taskManager.thirdTaskMoved) 
        {
            taskManager.thirdTaskMoved = false;
            taskManager.justDeletedThird = false;
            taskManager.newTaskCanBeCreated = true;
        }
    }

    public void DeleteMe()
    {
        if(taskPosition == 1)
        {
            taskManager.justDeletedFirst = true;
        }
        else if(taskPosition == 2)
        {
            taskManager.justDeletedSecond = true;
        }
        else if(taskPosition == 3)
        {
            taskManager.justDeletedThird = true;
        }
        taskManager.taskAmount--;
        Destroy(gameObject);
    }
}
