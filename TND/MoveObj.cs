using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    [SerializeField]
    private bool isMovableX = true;
    [SerializeField]
    private bool isMovableY = true;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float range;
    
    private float originPosX;
    private float originPosY;
    private float dirX = 1f;
    private float dirY = 1f;
    // Start is called before the first frame update
    void Start()
    {
        originPosX = this.transform.position.x;
        originPosY = this.transform.position.y;
    }

    // Update is called once per frame
    protected void Update()
    {
        switchDir();
        Move();
    }

    private void switchDir()
    {
        float _nowX = this.transform.position.x;
        float _nowY = this.transform.position.y;

        if(_nowX <originPosX-range) 
            dirX = 1;
        if (_nowX > originPosX + range)
            dirX = -1;
        if (_nowY < originPosY - range)
            dirY = 1;
        if (_nowY > originPosY + range)
            dirY = -1;
    }

    private void Move()
    {
        Vector3 _next = this.transform.position;
        if (isMovableX)
        {
            _next.x += Time.deltaTime * moveSpeed * dirX;

        }
        if (isMovableY)
        {
            _next.y += Time.deltaTime * moveSpeed * dirY;
        }
        this.transform.position = _next;
    }
}
