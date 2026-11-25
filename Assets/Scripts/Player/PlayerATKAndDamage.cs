using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKAndDamage : ATKAndDamage
{
    public float attackB = 80f;
    public float attackRange = 100f;
    public void AttackA()
    {
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (var item in SpawnManager.Instance.enemyList)
        {
            float temp = Vector3.Distance(item.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = item;
                distance = temp;
            }
        }

        if(enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }

    public void AttackB()
    {
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (var item in SpawnManager.Instance.enemyList)
        {
            float temp = Vector3.Distance(item.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = item;
                distance = temp;
            }
        }

        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    }

    public void AttackRange()
    {
        float distance = attackDistance;
        foreach (var item in SpawnManager.Instance.enemyList)
        {
            float temp = Vector3.Distance(item.transform.position, transform.position);
            if (temp < distance)
            {
                item.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
            }
        }
    }

    public void AttackGun()
    {

    }
}
