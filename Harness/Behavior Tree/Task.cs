using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    List<Task> childList = new List<Task>();
    protected List<Task> GetChild() { return childList; }

    public abstract bool Run();

    public void AddChild(Task task)
    {
        childList.Add(task);
    }
}
