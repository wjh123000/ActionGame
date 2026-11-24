using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoulBoss : MonoBehaviour
{
    private Transform player;
    public float attackDistance = 3f;
    private NavMeshAgent agent;
    private Animator animator;
    public float attackTime = 2f;
    private float attackTimer = 0f;
    private bool isAttacking = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        attackTimer = attackTime; // 初始化攻击计时器为攻击间隔时间，以便立即可以攻击
    }

    private void Update()
    {
        bool isRun = false;
        Vector3 targetPos = player.position;
        //targetPos.y = transform.position.y; // 保持y轴不变
        //transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
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

        if (distance > attackDistance)
        {
            attackTimer = attackTime; // 重置攻击计时器
            isRun = true;
            agent.SetDestination(targetPos);
            animator.SetBool("Walk", true);
        }
        else
        {
            isRun = false;
            agent.velocity = Vector3.zero;
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)
            {
                int num = Random.Range(0, 2);
                if (num == 0)
                {
                    animator.SetTrigger("Attack1");
                }
                else
                {
                    animator.SetTrigger("Attack2");
                }
                attackTimer = 0f;
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }

    }
}
