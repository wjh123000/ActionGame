using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoulMonster : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    private NavMeshAgent agent;

    public float attackDistance = 0.5f;
    private float attackTime = 1.5f;
    private float attackTimer = 0f;
    private bool isAttacking = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        isAttacking = false;
        attackTimer = attackTime; // 初始化攻击计时器为攻击间隔时间，以便立即可以攻击
    }

    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsTag("Attack"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        if (isAttacking)
        {
            agent.velocity = Vector3.zero;
            return;
        }

        float distance = Vector3.Distance(player.position, transform.position);
        if(distance > attackDistance)
        {
            agent.SetDestination(player.position);
            animator.SetBool("Walk", true);
            attackTimer = attackTime; // 重置攻击计时器
        }
        else
        {
            agent.velocity = Vector3.zero;
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackTime)
            {
                animator.SetTrigger("Attack");
                attackTimer = 0f; // 重置攻击计时器
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
    }
}
