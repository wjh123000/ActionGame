using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayAnimationAttack : MonoBehaviour
{
    public InputActionAsset asset;

    private void Update()
    {
        if (asset.FindAction("Attack").WasPressedThisFrame())
        {
            GetComponent<Animator>().SetTrigger("AttackA");
        }
        if (asset.FindAction("AttackRange").WasPressedThisFrame())
        {
            GetComponent<Animator>().SetTrigger("AttackA");
        }
    }

    public void OnNormalAttackClick()
    {

    }

    public void OnRangeAttackClick()
    {

    }

    public void OnRedAttackClick()
    {

    }


}
