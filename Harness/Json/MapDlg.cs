using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class MapDlg : ShowDlg
{
    public GameObject dog;
    DogMove dogMoveScript;
    public int day;
    int id;
    bool end = false;

    // Start is called before the first frame update
    new void Start()
    {
        day = GameManager.instance.getDay();
        switch (day)
        {
            case 1:
                id = 0;
                break;
            case 2:
                id = 9;
                break;
            case 3:
                id = 12;
                break;
            case 4:
                id = 15;
                break;
        }

        dogMoveScript = dog.GetComponent<DogMove>();
        dogMoveScript.enabled = false;  // 스크립트 표시할 때 움직이지 못하게

        Debug.Log("day: " + day + "id: " + id);

        base.Start();

        JsonPath = "/Plugins/MapDlgData.json";
        loadDlgNum = 1;
        dlgOn = false;
        dlgSet(dlgOn);
        dlgData = base.LoadDialogue(1);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeIn)
        {
            wait();
            return;
        }
        switch (day)
        {
            case 1:
                firstDlg();
                break;
            case 2:
                secondDlg();
                break;
            case 3:
                thirdDlg();
                break;
            case 4:
                fourthDlg();
                break;
        }
        if (end)
        {
            ending();
        }
    }

    void firstDlg()
    {
        if (id == 8)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void secondDlg()
    {
        if (id == 11)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void thirdDlg()
    {
        if (id == 14)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void fourthDlg()
    {
        if (id == 17)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }

    void ending()
    {
        if (dlgOn == true && Input.GetKeyUp(KeyCode.Return))
        {
            dlgSet(false);
            Debug.Log(",id: " + id);

            dogMoveScript.enabled = true;
        }
    }
}
