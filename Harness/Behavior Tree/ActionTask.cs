using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionTask : Task
{
    protected abstract int getState();
    protected void setResult(int result)
    {
        GameManager.instance.setBtresult(result);
    }
}
