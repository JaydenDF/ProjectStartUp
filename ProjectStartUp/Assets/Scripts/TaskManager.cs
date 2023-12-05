using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class TaskManager : MonoBehaviour
{
    //Rigidbody2D rb;
    //public List<GameObject> tasks = new List<GameObject>();

    public int taskAmount = 3;
    public float yFirstTask;
    public float ySecondTask;
    public float yThirdTask;

    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
