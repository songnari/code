using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Vector3 offset; // 기본 offset (-5.8, 6.5, -5)
    [SerializeField]
    private Vector3 zoomInOffset; // (-2.5, 4, -2)
    private Vector3 applyOffset; // 적용될 offset

    [SerializeField]
    private float zoomInSpeed = 0.2f;

    AudioSource BgmAudio;

    [SerializeField]
    private bool isZoomIn = false;

    StageTutorialMgr StMgr;

    // Start is called before the first frame update
    void Start()
    {
        BgmAudio = Camera.main.GetComponent<AudioSource>();
        BgmAudio.volume = PlayerPrefs.GetFloat("BgmSound");

        StMgr = GameObject.Find("StageTutorialMgr").GetComponent<StageTutorialMgr>();

        applyOffset = offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        TargetPosition();

        if (StMgr.isTalk == true)
        {
            TryZoomIn();
        }
        if (StMgr.isTalk == false)
        {
            TryZoomOut();
        }
    }
    

    private void TryZoomIn()
    {
        if (!isZoomIn) {
            isZoomIn = true;
            ZoomIn();
        }
    }

    private void TryZoomOut()
    {
        if (isZoomIn)
        {
            isZoomIn = false;
            ZoomOut();
        }
    }

    private void TargetPosition() // target을 따라 카메라 이동
    {
        Vector3 _targetPos = target.transform.position;
        this.transform.position = _targetPos + applyOffset;
    }

    private void ZoomIn()
    {
        StartCoroutine(ZoomInOutCoroutine(zoomInOffset));
    }

    private void ZoomOut()
    {
        StartCoroutine(ZoomInOutCoroutine(offset));
    }

    // 카메라 줌인, 아웃 움직임 부드럽게
    IEnumerator ZoomInOutCoroutine(Vector3 targetOffset)
    {
        Vector3 _temp = applyOffset;
        int count = 0;

        while(_temp != targetOffset)
        {
            if (count > 50) //무한루프 방지
              break;

            count++;

            _temp = Vector3.Lerp(_temp, targetOffset, zoomInSpeed);
            applyOffset = _temp;

            yield return null;
        }
        applyOffset = targetOffset;
    }
}
