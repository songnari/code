using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{
    public override bool Run()
    {
        foreach (Task child in GetChild()) // list 모두가 true여야 true
        {
            if (child.Run() == false)
                return false;
        }
        return true;
    }
}
