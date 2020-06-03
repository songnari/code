using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc : ActionTask
{
    public override bool Run()
    {
        Debug.Log("Npc State: " + getState());
        if (getState() < 5)
        {
            Debug.Log("==Npc fail ");
            return false;
        }

        Debug.Log("==Npc run");

        if (getState() > 6)
        {
            Debug.Log("==Obj end");
            GameManager.instance.setEndingNum(1);
            SceneManager.LoadScene("ending");
        }

        //내용
        setResult(1);

        return true;
    }

    protected override int getState()
    {
        return GameManager.instance.getNpcState();
    }
}
