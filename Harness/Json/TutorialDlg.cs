using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class TutorialDlg : ShowDlg
{
    public GameObject dog;
    public GameObject destination;
    public GameObject[] items;
    new JsonData dlgData;

    DogMove dogMoveScript;
    int id = 0; //dlg id
    int num = 0; //dlg num
    public int itemnum = 0; //tutorial item

    // Start is called before the first frame update
    new void Start()
    {
        dogMoveScript = dog.GetComponent<DogMove>();
        dogMoveScript.enabled = false;  // 스크립트 표시할 때 움직이지 못하게

        base.Start();
        JsonPath = "/Plugins/DlgData.json";
        loadDlgNum = 0;
        dlgOn = false;
        dlgSet(dlgOn);
        dlgData = base.LoadDialogue(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeIn)
        {
            wait();
            return;
        }
        switch (num)
        {
            case 0:
                FirstDlg();
                break;
            case 1:
                SecondDlg();
                break;
            case 2:
                setDestination();
                ThirdDlg();
                break;
        }
        if (id == 5 || id == 9)
        {
            if (dlgOn == true && Input.GetKeyUp(KeyCode.Return))
            {
                dlgSet(false);
                num++;
                Debug.Log("Dlg: " + num + ",id: " + id);

                dogMoveScript.enabled = true;
            }
        }
    }

    void FirstDlg()
    {
        dlgText.text = dlgData[id]["Dlg"].ToString();
        dlgText.gameObject.SetActive(dlgOn);
        if (Input.GetKeyUp(KeyCode.Return))
        {
            id++;
            dlgText.text = dlgData[id]["Dlg"].ToString();
            dlgText.gameObject.SetActive(dlgOn);
        }
    }
    void SecondDlg()
    {
        if (itemnum == 5)
        {
            dogMoveScript.enabled = false;

            dlgSet(true);
            dlgText.text = dlgData[id]["Dlg"].ToString();
            if (Input.GetKeyUp(KeyCode.Return))
            {
                id++;
                dlgText.text = dlgData[id]["Dlg"].ToString();
                dlgText.gameObject.SetActive(dlgOn);
            }
        }
    }
    void ThirdDlg()
    {
        if (itemnum == 5 && Input.GetKey(KeyCode.Space))
        {
            dlgSet(true);
            dlgText.text = dlgData[9]["Dlg"].ToString();
        }
    }

    void setDestination()
    {
        dog.transform.GetComponent<DogNevTutorial>().enabled = true;
        destination.SetActive(true);
    }
}
