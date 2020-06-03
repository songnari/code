using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public bool isFadeOut = false;
    public bool isNext = false;
    public bool isFadeIn = true;

    Image m_RawImage;
    Color tempColor;

    float fadeInOutTime, timer;

    // Start is called before the first frame update
    void Start()
    {
        m_RawImage = this.GetComponent<Image>();
        tempColor = m_RawImage.color;

        fadeInOutTime = 2.0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
            fadeIn();
        else
        {
            if (isFadeOut)
                fadeOut();
        }
        
    }

    void fadeIn() // 투명하게 해서 화면 밝아지는 효과
    {
        tempColor.a -= Time.deltaTime / fadeInOutTime;
        m_RawImage.color = tempColor;
        if (tempColor.a <= 0f)
        {
            tempColor.a = 0f;
            timer += Time.deltaTime;
            if (timer > 2)
                isFadeIn = false;
        }
    }

    void fadeOut() // 불투명하게 해서 화면 어두워지는 효과
    {
        tempColor.a += Time.deltaTime / fadeInOutTime;
        m_RawImage.color = tempColor;
        if (tempColor.a >= 1f)
        {
            tempColor.a = 1f;
            isFadeOut = true;
            if(isNext)
                this.GetComponent<nextSceneLoader>().isNext = true;
        }
    }
}
