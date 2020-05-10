using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Collider mCollider;
    private float dmgRate = 1.6f;
    private float nextAttack = 0.0f;

    private void Start()
    {
        mCollider = GetComponent<Collider>();
    }
    private void Update()
    {
        Attack();
    }
    private void Attack()
    {
        //마우스 왼쪽 버튼 눌렀을 시에 충돌주기 (1.3초의 딜레이)
        if (Input.GetMouseButtonDown(0)&&Time.time>nextAttack)
        {
            mCollider.enabled = true;
            nextAttack = Time.time + dmgRate;
        }
        else
        {
            mCollider.enabled = false;
        }
    }
    //콜라이더 충돌
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}
