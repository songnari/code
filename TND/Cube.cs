using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MoveObj
{
    [SerializeField]
    private bool isFallingCude = false;
    [SerializeField]
    private float fallingSpeed;
    [SerializeField]
    private float limitPosY;
    [SerializeField]
    private float waitingTime; //떨어지기 전 대기시간

    private float originPosY;
    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        originPosY = this.transform.position.y;
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    { 
        base.Update();
        if (isFallingCude)
            TryFalling();


    }

    private void TryFalling()
    {
        //대기시간 체크
        if (Timer < waitingTime)
        {
            Timer += Time.deltaTime;
            return;
        }

        Falling();
    }

    private void Falling()
    {
        Vector3 _nowPos = this.transform.position;
        if (_nowPos.y < originPosY - limitPosY)// 정해진 위치까지만 내려감
        {
            isFallingCude = false;
            return;
        }

        _nowPos.y -= Time.deltaTime * fallingSpeed;
        this.transform.position = _nowPos;
    }

    void OnCollisionEnter(Collision col)
    {
        //플레이어와 접촉시 바로 떨어짐
        if(col.gameObject.tag == "Player")
        {
            Timer = waitingTime;
        }
    }
}
