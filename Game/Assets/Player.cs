using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int isHp = 5;
    public int damage = 1;

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private Transform tr;

    public float moveSpeed = 1.5f;

    float rotSpeed = 3.0f;

    private Rigidbody myRigid;
    private Animator PlayerAnimation;

    private void Start()
    {
        tr = GetComponent<Transform>();
        myRigid = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        
        float MouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotSpeed * MouseX);
    }
    private void Move()
    {
        //Y축 고정
        transform.position = new Vector3(transform.position.x, -4.24f, transform.position.z);

        // 플레이어 움직임
        if (Input.GetKey(KeyCode.A))
        {
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        //공격모션
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimation.SetBool("Atk", true);
        }
        else
        {
            PlayerAnimation.SetBool("Atk", false);
        }
        //방어모션
        if (Input.GetMouseButtonDown(1))
        {
            PlayerAnimation.SetBool("Cover", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            PlayerAnimation.SetBool("Cover", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
            Debug.Log("닿았습니다.");
    }
}