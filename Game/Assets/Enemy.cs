using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{

    public int HP = 5;
    public int damage = 1;
    public float moveSpeed = 1f;

    private Animator EnemyAnimation;

    GameObject _Enemy;

    public Transform target;
    NavMeshAgent nav;

    public void TakeDamage(int damage)
    {
        HP--;
        if (HP == 4)
        {
            EnemyAnimation.SetTrigger("GetHit");
        }
        if (HP == 3)
        {
            EnemyAnimation.SetTrigger("GetHit");
        }
        if (HP == 2)
        {
            EnemyAnimation.SetTrigger("GetHit");
        }
        if (HP == 1)
        {
            EnemyAnimation.SetTrigger("GetHit");
        }
        if (HP == 0)
        {
            EnemyAnimation.SetTrigger("Death");
        }
    }
    private Rigidbody rigid;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        EnemyAnimation = GetComponent<Animator>();

        _Enemy = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();
        //Y축 고정
        transform.position = new Vector3(transform.position.x, -0.18f, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(_Enemy.transform.position);

        AnimationUpdate();
        if (HP == 0)
        {
            transform.position = new Vector3(0, -0.18f, 0);
        }
    }
    void AnimationUpdate()
    {
        if (nav.destination != transform.position)
            EnemyAnimation.SetBool("Walk", true);
        else
            EnemyAnimation.SetBool("Walk", false);
    }

}