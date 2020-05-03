using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    GameObject Player;
    GameObject Sword;

    bool GetHit;

    public float Hp;
    public float damage;
    public float moveSpeed = 1f;

    public enum State
    {
        Idle,
        Walk,
        Attack,
        Cover,
        GetHit,
        Death
    }
    public Animator anim;
    public State EnemyState;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        Hp = 5f;
        damage = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, -4.24f, transform.position.z);

        switch (EnemyState)
        {
            case State.Idle:
                break;
            case State.Walk:
                break;
            case State.Attack:
                break;
            case State.GetHit:
                break;
            case State.Cover:
                break;
            case State.Death:
                break;
        }

        void ChangeState(State EnemyState)
        {
            switch (EnemyState)
            {
            }
            this.EnemyState = EnemyState;

            //스테이트에서 들어가고나서 처음으로 실행되는 Enter()함수;
            switch (EnemyState)
            {
            }

        }
    }
}