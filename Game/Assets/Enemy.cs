using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public int HP = 3;
    public float damage;
    public float moveSpeed = 1f;

    public void TakeDamage(int damage)
    {
        HP = HP - damage;
    }

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