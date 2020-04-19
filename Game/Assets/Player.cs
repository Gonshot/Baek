using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 0;
    public float Dmg = 0;
    public float Move = 0f;
    Animator animator;
    bool Walk = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.A)==true)
        {
            transform.position += Vector3.left * Time.deltaTime * Move;
        }
        else if (Input.GetKey(KeyCode.S)==true)
        {
            transform.position += Vector3.back * Time.deltaTime * Move;
        }
        else if (Input.GetKey(KeyCode.D)==true)
        {
            transform.position += Vector3.right * Time.deltaTime * Move;
        }
        else
        {
            Walk = false;
        }
    }
}
