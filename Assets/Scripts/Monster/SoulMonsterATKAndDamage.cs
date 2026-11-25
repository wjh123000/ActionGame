using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonsterATKAndDamage : ATKAndDamage
{
    private Transform player;
    private void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    public void MonAttack()
    {
        if (Vector3.Distance(player.position, transform.position) < attackDistance)
        {
            player.GetComponent<PlayerATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
