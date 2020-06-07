using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class aEnemy : MonoBehaviour
{

    public int HP = 5;
    public int damage = 1;
    public float moveSpeed = 1f;    
    public Animator EnemyAnimation;
    public Transform target;


    GameObject _Enemy;
    NavMeshAgent nav;


    //데미지 받을시에 나오는 모션
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
    private float randommotion;
    
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        EnemyAnimation = GetComponent<Animator>();


        _Enemy = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();
        //Y축 고정
        transform.position = new Vector3(transform.position.x, -0.18f, transform.position.z);
        randommotion = Random.Range(1f, 10f);
    }
    // Update is called once per frame
    void Update()
    {
        //플레이어를 따라가는 AI
        nav.SetDestination(_Enemy.transform.position);

        AnimationUpdate();
        //HP 0이 될 경우 네비와 적 5초 딜레이 후 삭제
        if (HP == 0)
        {
            Destroy(nav);
            Destroy(GameObject.FindGameObjectWithTag("EnemySword"));
            Destroy(GameObject.FindGameObjectWithTag("Enemy"), 7f);
        }

        target = GameObject.Find("Player").transform;


        float distance = Vector3.Distance(target.position, transform.position);

        //플레이어랑 가까워질 경우 공격모션
        
            if (distance <= 1.5f)
            {
            EnemyAnimation.SetTrigger("Atk");
        }
    }
    //안 움직일 경우 이동모션 세팅
    void AnimationUpdate()
    {
        if (nav.destination != transform.position)
            EnemyAnimation.SetBool("Walk", true);
        else
            EnemyAnimation.SetBool("Walk", false);
    }
}