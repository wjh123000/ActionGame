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
    }

    private void Update()
    {

        if (asset.FindAction("Attack").WasPressedThisFrame())
        {
            if (!isAttacking)
            {
                StartAttack1();
            }
            else if (isAttacking && canCombo)
            {
                comboQueued = true; //记录玩家按下了攻击（预输入）
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
        isAttacking = true;
    }

    private void FixedUpdate()
    {
        animator.SetBool("comboQueued", comboQueued);
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
        isAttacking = true;
        canCombo = false;
        comboQueued = false;
        animator.SetTrigger("AttackA");
    }


    public void OpenComboWindow()
    {
        canCombo = true;
    }

    public void CloseComboWindow()
    {
        isAttacking = false;
        if (comboQueued)
        {
            //Debug.Log("Combo Queued! Starting Attack 2");
            StartAttack2();
        }
        
        canCombo = false;
        //comboQueued = false;
    }

    public void StartAttack2()
    {
        isAttacking = true;
        canCombo = false;
        animator.SetTrigger("AttackB");
    }
    public void EndAttack()
    {
        //Debug.Log("EndAttack");
        comboQueued = false;
        isAttacking = false;
    }
}
