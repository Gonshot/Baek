using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class EnemySword : MonoBehaviour
{
    public Collider mCollider;
    public float dmgRate = 1.8f;
    public float nextAttack = 0.0f;
    public Transform target;

    private void Start()
    {
        mCollider = GetComponent<Collider>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Attack();
    }
    private void Attack()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //플레이어랑 가까워 졌을 시 공격(1.67초의 딜레이)

        if (distance <= 0.42f && Time.time > nextAttack)
        {
            mCollider.enabled = true;
            nextAttack = Time.time + dmgRate;
        }
        else
        {
            mCollider.enabled = false;
        }
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            target.GetComponent<Player>().TakeDamage(1);
        }
    }
    
}
