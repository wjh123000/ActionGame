using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBoss : MonoBehaviour
{
    private Transform player;
    public float attackDistance = 3f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    private void Update()
    {
        bool isRun = false;
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y; // 保持y轴不变
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance > attackDistance)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

    }
}
