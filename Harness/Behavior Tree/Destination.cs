using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : ActionTask
{
    public override bool Run()
    {
        Debug.Log("Destination State: " + getState());
        if (getState() < 2)
        {
            Debug.Log("==Destination fail ");
            return false;
        }

        Debug.Log("==Destination run");

        //내용
        setResult(2);
        return true;
    }

    protected override int getState()
    {
        return GameManager.instance.getDestinationState();
    }
}
