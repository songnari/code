using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTree : MonoBehaviour
{
    public static BTTree instance = null;
    Selector rootSelector;

    // Start is called before the first frame update
    void Awake()
    {
        //singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
        rootSelector = new Selector();
        Sequence seq = new Sequence();

        rootSelector.AddChild(new Obj());
        rootSelector.AddChild(new Npc());
        rootSelector.AddChild(new Destination());
        

        rootSelector.AddChild(seq);
    }

    public void Run()
    {
        bool runResult = rootSelector.Run();

        if (!runResult)
        {
            Debug.Log("btree fail"); // 추가 구현하면 좋을텐데
        }
    }
    
}
