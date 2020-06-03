using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class EndingDlg : ShowDlg
{
    public GameObject[] background_img;
    public GameObject[] end_img;
    public int img_num;
    int id;
    bool end = false;


    public bool isEndReal = false;
    public bool isEndBus = false;
    public bool isEndSnack = false;
    public bool isEndPark = false;
    
    void Awake()
    {
        int num = GameManager.instance.getEndingNum();

        switch (num)
        {
            case 0:
                isEndReal = true;
                isEndBus = false;
                isEndSnack = false;
                isEndPark = false;
                break;
            case 1:
                isEndReal = false;
                isEndBus = true;
                isEndSnack = false;
                isEndPark = false;
                break;
            case 2:
                isEndReal = false;
                isEndBus = false;
                isEndSnack = true;
                isEndPark = false;
                break;
            case 3:
                isEndReal = false;
                isEndBus = false;
                isEndSnack = false;
                isEndPark = true;
                break;
        }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        JsonPath = "/Plugins/EndDlgData.json";
        loadDlgNum = 5;
        dlgOn = false;
        dlgSet(dlgOn);
        dlgData = base.LoadDialogue(5);
        Set();
        background_img[img_num].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeIn)
        {
            wait();
            return;
        }
        switch (img_num)
        {
            case 0:
                EndDlg_Real();
                break;
            case 1:
                EndDlg_Bus();
                break;
            case 2:
                EndDlg_Snack();
                break;
            case 3:
                EndDlg_Park();
                break;
        }
        if (end) { ending(); }
    }
    //엔딩대사 0-3 진엔딩, 4-8 버스엔딩 9-13 간식엔딩 14-18 자판기엔딩
    void EndDlg_Real()
    {
        if (id == 3)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void EndDlg_Bus()
    {
        if (id == 8)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void EndDlg_Snack()
    {
        if (id == 13)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
    void EndDlg_Park()
    {
        if (id == 18)
        {
            end = true;
            return;
        }
        id = nextText(id);
    }
  
    void Set()
    {
        if (isEndReal) { id = 0; img_num = 0; }
        if (isEndBus) { id = 4; img_num = 1; }
        if (isEndSnack) { id = 9; img_num = 2; }
        if (isEndPark) { id = 14; img_num = 3; }
    }
    void ending()
    {
        if (dlgOn == true && Input.GetKeyUp(KeyCode.Return))
        {
            dlgSet(false);
            end_img[img_num].SetActive(true);
            if (Input.GetKeyUp(KeyCode.Return))
            {
                UIFade.GetComponent<FadeInOut>().isFadeOut = true;
                nextSceneLoader.nextSceneName = "startMenu";
                UIFade.GetComponent<FadeInOut>().isNext = true;
            }
        }
        
    }
}
