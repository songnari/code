using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task
{
    public override bool Run()
    {
        foreach (Task child in GetChild()) // list중 하나라도 true면 true
        {
            if (child.Run())
                return true;
        }
        return false;
    }
}
