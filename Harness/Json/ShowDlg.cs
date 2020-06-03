using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class ShowDlg : MonoBehaviour
{
    public Text dlgText;
    public GameObject dialogue;
    public GameObject UIFade;
    
    public string JsonPath;

    protected nextSceneLoader nextSceneLoader;
    protected int loadDlgNum; // 상속시 입력해야함
    protected JsonData dlgData;

    Image m_RawImage;

    protected bool fadeIn, dlgOn;

    // Start is called before the first frame update
    protected void Start()
    {
        m_RawImage = UIFade.GetComponent<Image>();
        nextSceneLoader = UIFade.GetComponent<nextSceneLoader>();

        fadeIn = false;
        dlgOn = false;

        LoadDialogue(loadDlgNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void dlgSet(bool on)
    {
        dlgOn = on;
        dialogue.SetActive(dlgOn);
        dlgText.gameObject.SetActive(dlgOn);
    }

    protected void wait()
    {
        if (m_RawImage.color.a < 0f)
        {
            fadeIn = true;
            dlgSet(true);
        }
    }

    protected int nextText(int id)
    {
        dlgText.text = dlgData[id]["Dlg"].ToString();
        dlgText.gameObject.SetActive(dlgOn);
        if (Input.GetKeyUp(KeyCode.Return))
        {
            id++;
            dlgText.text = dlgData[id]["Dlg"].ToString();
            dlgText.gameObject.SetActive(dlgOn);
        }
        return id;
    }

protected JsonData LoadDialogue(int dlgNum)
    {
        JsonData dlgData;

        if (!File.Exists(Application.dataPath + JsonPath))
            this.GetComponent<SaveDlg>().SaveDialogue(dlgNum);
            
        string str = File.ReadAllText(Application.dataPath + JsonPath);
        dlgData = JsonMapper.ToObject(str);
        return dlgData;
    }
}
