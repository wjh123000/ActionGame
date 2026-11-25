using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100f;
    public float normalAttack = 50f;
    public float attackDistance = 1.5f;
    protected Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;

        }
        if (hp > 0)
        {
            animator.SetTrigger("Damage");
            if (this.tag == Tags.soulBoss)
            {
                GameObject.Instantiate(Resources.Load("HiBoss"), transform.position, transform.rotation);
            }
            else if (this.tag == Tags.soulMonster)
            {
                GameObject.Instantiate(Resources.Load("HiMonster"), transform.position, transform.rotation);
            }
        }
        else
        {
            animator.SetBool("Dead", true);
        }
    }
}
