using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayAnimationAttack : MonoBehaviour
{
    public InputActionAsset asset;
    private Animator animator;
    public static bool isAttacking = false;
    private bool canCombo = false;    // 是否在允许衔接的窗口期
    private bool comboQueued = false; // 玩家是否在窗口期按下了攻击键

    private void Awake()
    {
        asset.Enable();
        animator = GetComponent<Animator>();
        animator.SetBool("comboQueued", comboQueued);
    }

    private void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        bool inAnyAttack = state.IsTag("Attack");
        if(!inAnyAttack)
        {
            isAttacking = false;
            canCombo = false;
            comboQueued = false;
            animator.SetBool("comboQueued", false);
        }
        else
        {
            isAttacking = true;
        }

        if (asset.FindAction("Attack").WasPressedThisFrame())
        {
            if (!isAttacking)
            {
                StartAttack1();
            }
            else if (isAttacking && canCombo)
            {
                comboQueued = true; //记录玩家按下了攻击（预输入）
                animator.SetBool("comboQueued", comboQueued);
            }
        }

        if (asset.FindAction("AttackRange").WasReleasedThisFrame())
        {

            StartAttackRange();
        }

    }

    public void StartAttackRange()
    {
        animator.SetTrigger("AttackRange");
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            PlayerControl.CanMove = false;
        }
        else
        {
            PlayerControl.CanMove = true;
        }
    }

    void StartAttack1()
    {
        canCombo = false;
        comboQueued = false;
        animator.SetBool("comboQueued", comboQueued);
        animator.SetTrigger("AttackA");
    }


    public void OpenComboWindow()
    {
        canCombo = true;
    }

    public void CloseComboWindow()
    {
        if (comboQueued == true)
        {
            StartAttack2();
        }
        canCombo = false;
    }

    public void StartAttack2()
    {
        canCombo = false;
        animator.SetTrigger("AttackB");
    }
    public void EndAttack()
    {
        comboQueued = false;
        animator.SetBool("comboQueued", comboQueued);
        animator.SetFloat("Speed", 0f);
    }
}
