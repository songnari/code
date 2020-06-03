using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDlg : ShowDlg
{
    public GameObject dog;
    DogMove dogMoveScript;
    bool end = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        dogMoveScript = dog.GetComponent<DogMove>();


        JsonPath = "/Plugins/NpcDlgData.json";
        loadDlgNum = 4;
        dlgOn = false;
        dlgSet(dlgOn);
        dlgData = base.LoadDialogue(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            ending();
        }
    }

    public void npcDlg(int id) //실행한 npcDlg.cs의 id값을 받아옴
    {
        dogMoveScript.enabled = false;  // 스크립트 표시할 때 움직이지 못하게
        dlgSet(true);
        nextText(id); // id값 대사 출력
        end = true;
    }

    void ending()
    {
        if (dlgOn == true && Input.GetKeyUp(KeyCode.Return))
        {
            dlgSet(false);

            dogMoveScript.enabled = true;
            end = false;
        }
    }
}
