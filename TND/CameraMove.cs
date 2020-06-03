using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float xMargin = 1f; //카메라가 따라 가기 전에 플레이어가 이동할 수있는 x 축의 거리.
    public float yMargin = 1f; //카메라가 따라 가기 전에 플레이어가 이동할 수있는 y 축의 거리.
    public float xSmooth = 8f; //카메라가 x 축에서 목표 이동을 따라 잡는 것이 얼마나 부드럽게 수행되는지.
    public float ySmooth = 8f; //카메라가 y 축에서 목표 이동을 따라 잡는 것이 얼마나 부드럽게 수행되는지
    public Vector2 maxXY; //카메라가 가질 수 있는 최대 x좌표
    public Vector2 minXY; //카메라가 가질 수 있는 최대 x좌표

    private Transform player; 

    void Start()
    {
        Screen.SetResolution(960,600, false);
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //카메라와 플레이어 사이의 거리가 Margin보다 큰 경우 true
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        //현재 카메라의 좌표
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        //player가 margin을 넘어서면 target 좌표는 카메라의 현재 위치와 플레이어의 현재 위치 사이의 Lerp 여야합니다.
        if (CheckXMargin())
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        if (CheckYMargin())
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

        //카메라 거리 제한
        targetX = Mathf.Clamp(targetX, minXY.x, maxXY.x);
        targetY = Mathf.Clamp(targetY, minXY.y, maxXY.y);
        //카메라 위치 설정
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
