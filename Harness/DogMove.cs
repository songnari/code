using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    public float speed = 6f;
    public float turnSpeed = 2f;
    public GameObject dog;

    Vector3 movement;
    Rigidbody rigid, dogRigid;
    Animator animator;
    Quaternion ro = Quaternion.Euler(0f, -90f, 0);
    // Start is called before the first frame update
    void Start()
    {
        dogRigid = dog.GetComponent<Rigidbody>();
        rigid = GetComponent<Rigidbody>();
        animator = dog.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = rigid.transform.forward * speed * Time.deltaTime;
        AnimationSet();

        Move();
        Turn();
    }

    void AnimationSet()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("walk", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("walk", false);
        }
    }
    
    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rigid.MovePosition(transform.position + movement);
            this.transform.position = transform.position + movement;

            dog.transform.position = new Vector3(this.transform.position.x, dog.transform.position.y, this.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //rigid.MovePosition(transform.position - movement);
            this.transform.position = transform.position - movement;
            dog.transform.position = new Vector3(this.transform.position.x, dog.transform.position.y, this.transform.position.z);
        }
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion rotation = Quaternion.Euler(rigid.transform.up * turnSpeed);
            //rigid.MoveRotation(rigid.rotation * rotation);
            this.transform.rotation = rigid.rotation * rotation;
            dog.transform.rotation = this.transform.rotation * ro;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion rotation = Quaternion.Euler(-rigid.transform.up * turnSpeed);
            //rigid.MoveRotation(rigid.rotation * rotation);
            this.transform.rotation = rigid.rotation * rotation;
            dog.transform.rotation = this.transform.rotation * ro;
        }
    }
}
