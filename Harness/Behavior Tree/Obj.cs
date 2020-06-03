using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obj : ActionTask
{
    public override bool Run()
    {
        Debug.Log("Obj State: " + getState());
        if (getState() < 5)
        {
            Debug.Log("==Obj fail ");
            return false;
        }

        Debug.Log("==Obj run");

        if (getState() > 6)
        {
            Debug.Log("==Obj end");
            GameManager.instance.setEndingNum(2);
            SceneManager.LoadScene("ending");
        }

        setResult(0);

        return true;
    }

    protected override int getState()
    {
        return GameManager.instance.getObjState();
    }
}
