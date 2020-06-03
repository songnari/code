using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class DayDlg : ShowDlg
{
    public GameObject[] backgroundImage;
    public int day;
    int id;
    bool end = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        JsonPath = "/Plugins/DayDlgData.json";
        loadDlgNum = 0;
        dlgOn = false;
        dlgSet(dlgOn);
        dlgData = base.LoadDialogue(2);

        day = GameManager.instance.getDay();
        backgroundImage[day-1].SetActive(true);
        switch (day)
        {
            case 1:
                id =0;
                break;
            case 2:
                id =4;
                break;
            case 3:
                id =8;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (day == 4)
        {
            nextSceneLoader.nextSceneName = "park";
            UIFade.GetComponent<FadeInOut>().isFadeOut = true;
            UIFade.GetComponent<FadeInOut>().isNext = true;
            fadeIn = true;
        }
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
        }
        if (end)
        {
            ending();
        }
    }
    void firstDlg()
    {
        if (id == 3)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void secondDlg()
    {
        if (id == 7)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void thirdDlg()
    {
        if (id == 18)
        {
            nextSceneLoader.nextSceneName = "bookstore";
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
            UIFade.GetComponent<FadeInOut>().isFadeOut = true;
            UIFade.GetComponent<FadeInOut>().isNext = true;
        }
    }
}
