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

    private float coverRate = 1.0f;
    private float nextAttack = 0.0f;

    public Collider _Collider;
    private Transform tr;

    public float moveSpeed = 2f;

    float rotSpeed = 5.0f;

    private Rigidbody myRigid;
    private Animator PlayerAnimation;
    public void TakeDamage(int damage)
    {
        isHp--;
        //데미지 받았을 시 모션
        if (isHp == 4)
        {
            PlayerAnimation.SetTrigger("GetHit");
        }
        if (isHp == 3)
        {
            PlayerAnimation.SetTrigger("GetHit");
        }
        if (isHp == 2)
        {
            PlayerAnimation.SetTrigger("GetHit");
        }
        if (isHp == 1)
        {
            PlayerAnimation.SetTrigger("GetHit");
        }
        if (isHp <= 0)
        {
            PlayerAnimation.SetTrigger("Death");
        }
    }

    private void Start()
    {
        tr = GetComponent<Transform>();
        myRigid = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        //플레이어 이동
        Move();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);


        float MouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotSpeed * MouseX);

        if (isHp <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Sword"));
            Destroy(GameObject.FindGameObjectWithTag("Player"), 4.3f);
        }
    }
    private void Move()
    {
        //Y축 고정
        transform.position = new Vector3(transform.position.x, -0.18f, transform.position.z);
        if (transform.position.x >= 4.5f)
        {
            transform.position = new Vector3 (4.5f, 0.18f, transform.position.z);
        }
        if (transform.position.x <=-4.5f)
        {
            transform.position = new Vector3(-4.5f, 0.18f, transform.position.z);
        }
        if (transform.position.z <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.18f, -4.5f);
        }
        if (transform.position.z >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.18f, 4.5f);
        }

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
            _Collider.enabled = false;
        }
        if (Input.GetMouseButtonUp(1) && Time.time > nextAttack)
        {
            PlayerAnimation.SetBool("Cover", false);
            _Collider.enabled = true;
            nextAttack = Time.time + coverRate;
        }
    }
}
