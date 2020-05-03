using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float isHp;
    public float damage;
    public float moveSpeed = 1.5f;
    float rotSpeed = 3.0f;

    private Animator PlayerAnimation;

    private void Start()
    {
        PlayerAnimation = GetComponent<Animator>();
        Hp = 5f;
        damage = 1f;
    }

    void Update()
    {
        Move();

        //마우스 좌우 움직임으로 카메라 전환, 회전 X,Z축 고정
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
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            PlayerAnimation.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnimation.SetBool("Walk", false);
        }
        //공격모션
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimation.SetBool("Attack 01", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            PlayerAnimation.SetBool("Attack 01", true);
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
    public void Attack()
    {

    }
}