using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100f;
    public float normalAttack = 1f;
    public float attackDistance = 1.5f;
    protected Animator animator;

    protected void Awake()
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
            if(this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                animator.SetTrigger("Damage");
            }
            
        }
        else
        {
            animator.SetBool("Dead", true);
            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                SpawnManager.Instance.enemyList.Remove(this.gameObject);
                Destroy(this.gameObject, 1f);
            }
                
        }
        if (this.tag == Tags.soulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        }
        else if (this.tag == Tags.soulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
        }
    }
}
