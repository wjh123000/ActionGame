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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isRun = false;
        Vector3 targetPos = player.position;
        //targetPos.y = transform.position.y; // 保持y轴不变
        //transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance > attackDistance)
        {
            isRun = true;
            agent.SetDestination(targetPos);
            animator.SetBool("Walk", true);
        }
        else
        {
            isRun = false;
            agent.velocity = Vector3.zero;
            animator.SetBool("Walk", false);
            
        }

    }
}
