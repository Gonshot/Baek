using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Hp;
    public float damage;
    public float moveSpeed = 1f;

    private Animator anima;
    private bool Walk;

    // Use this for initialization
    private void Start()
    {
        anima = GetComponent<Animator>();
        Move();

    }




    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //Y축과 회전 고정
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, -4.44f, transform.position.z);
        if (Input.GetKey(KeyCode.A))
        {
            Walk = true;
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            anima.SetTrigger("Walk");
        }
        else
        {
            Walk = false;
            anima.SetTrigger("Idle");
        }
        if (Input.GetKey(KeyCode.W))
        {
            Walk = true;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            anima.SetTrigger("Walk");
        }
        else
        {
            Walk = false;
            anima.SetTrigger("Idle");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Walk = true;
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            anima.SetTrigger("Walk");
        }
        else
        {
            Walk = false;
            anima.SetTrigger("Idle");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Walk = true;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            anima.SetTrigger("Walk");
        }
        else
        {
            Walk = false;
            anima.SetTrigger("Idle");
        }
    }
}