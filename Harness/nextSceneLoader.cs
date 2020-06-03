using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextSceneLoader : MonoBehaviour
{
    public string nextSceneName;
    public bool isNext = false;
    public bool goToMap = false;

    public int day;

    void Start()
    {
        day = GameManager.instance.getDay();
    }

    void Update()
    {
        if(isNext)
            SceneManager.LoadScene(getNextSceneName());
    }

    string getNextSceneName()
    {
        if (!goToMap)
            return nextSceneName;
        
        return "map1";
    }
}
