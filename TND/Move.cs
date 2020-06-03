using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public int Speed;
    Animator anim;
    float horizontalMove;

    public GameObject[] dogs;
    public int dogsNumber;
    public GameObject cube;

    private Transform dog;


    private bool isJumping=false;
    private bool isDamaging=false;
    private bool isLookRight=true;

    private float posY; //dog의 초기 높이
    private float gravity; //중력 가속도
    private float jumpPower; //점프력
    private float jumpTime; //점프 이후 경과시간
    private float damageTime;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        dog = this.transform;
        posY = dog.position.y;

        gravity=120.8f;
        jumpPower = 80.0f;
        jumpTime = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
        Moving();
        TryJump();
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.Space))
            anim.SetInteger("State", 0);
        
        
    }
    private void CheckDamage()
    {
        if (isDamaging)
        {
            Damage();
        }
    }

    private void TryJump()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            posY = dog.position.y;
        }

        if (isJumping)
        {
            Jump();
        }
    }

    private void Moving()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float _dir = Input.GetAxisRaw("Horizontal");
            if (isLookRight && _dir < 0)
            {
                isLookRight = false;
                transform.RotateAround(cube.transform.position, Vector3.up, 180f);
            }
            else if (!isLookRight && _dir > 0)
            {
                isLookRight = true;
                transform.RotateAround(cube.transform.position, Vector3.up, 180f);
            }
            anim.SetInteger("State", 1);
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }

    void Jump()
    {
        anim.SetInteger("State", 2);
        //y=(-a/2)*x*x +(b*x) (x:점프시간, y:dog의 높이, a:중력가속도, b:초기 점프속도)
        float height = (jumpTime * jumpTime * (-gravity) / 2) + jumpTime * jumpPower;
        dog.position = new Vector3(dog.position.x, posY + height, dog.position.z);
        jumpTime += Time.deltaTime;

        //처음 높이보다 내려갔을 때, 점프 전 상태로 복귀.
        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
            dog.position = new Vector3(dog.position.x, posY, dog.position.z);
            anim.SetInteger("State", 0);
        }
    }
    void Damage()
    {
        anim.SetInteger("State", 3);
        damageTime += Time.deltaTime * 10f;
        if (damageTime > 12f)
        {
            isDamaging = false;
            anim.SetInteger("State", 0);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Monster")
        {
            damageTime = 0.0f;
            isDamaging = true;
        }
        if (col.tag == "Obstacles")
        {
            damageTime = 0.0f;
            isDamaging = true;
            col.gameObject.SetActive(false);
        }
        if (col.tag == "Floor")
        {
            isJumping = false;
            jumpTime = 0.0f;
            anim.SetInteger("State", 0);
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Monster" || col.tag == "Obstacles")
        {
            isDamaging = true;
        }
    }

}
