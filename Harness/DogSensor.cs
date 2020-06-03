using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogSensor : MonoBehaviour
{
    public GameObject fade;
    public GameObject questionMark;
    public GameObject exclamaion;

    TutorialItem tutorialItem;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Destination")
        {
            fade.GetComponent<FadeInOut>().isFadeOut = true;
            fade.GetComponent<FadeInOut>().isNext = true;
        }

        if(other.tag == "TutorialItem")
        {
            tutorialItem = other.GetComponent<TutorialItem>();
            if (!tutorialItem.find)
            {
                questionMark.SetActive(true);
            }
        }

        if(other.tag == "item" || other.tag == "Npc")
        {
            questionMark.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "TutorialItem")
        {
            if (tutorialItem.find)
            {
                questionMark.SetActive(false);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    tutorialItem.getItem();
                }
            }
        }

        /* 신호등 처리 
        if (other.tag == "crosswalk")
        {
            if (other.GetComponent<Crosswalk>().isRed)
                exclamaion.SetActive(true);
            else
                exclamaion.SetActive(false);
        }
        */

        if (questionMark.activeSelf)
        {
            if (other.tag == "item")
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    //GameManager.instance.findItem();
                    other.GetComponent<Items>().showDlg();
                    questionMark.SetActive(false);
                }
            }
            if (other.tag == "Npc")
            {
                if (Input.GetKeyUp(KeyCode.T))
                {
                    //GameManager.instance.findNpc();
                    other.GetComponent<Npcs>().showDlg();
                    questionMark.SetActive(false);
                }
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "TutorialItem")
        {
            questionMark.SetActive(false);
        }

        /* 신호등 처리 
        if (other.tag == "crosswalk")
        {
            exclamaion.SetActive(false);
        }
        */

        if (other.tag == "item")
        {
            questionMark.SetActive(false);
        }

        if (other.tag == "Npc")
        {
            questionMark.SetActive(false);
            other.GetComponent<Npcs>().moveNpc();
        }
    }
}
