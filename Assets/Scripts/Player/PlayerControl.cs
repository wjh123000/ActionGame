using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InputActionAsset asset;
    private Rigidbody rb;
    private Animator animator;
    public float speed = 2f;
    public static bool CanMove = true;

    void Start()
    {
        asset.Enable();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (asset.FindAction("Jump").WasPressedThisFrame())
        {
            if(transform.position.y < 0.6f)
            {
                rb.AddForce(Vector3.up * 200);
                animator.SetTrigger("Jump");
            }
            
        }
    }
    void FixedUpdate()
    {
        Vector2 dir = asset.FindAction("Move").ReadValue<Vector2>();
        
        if (dir != Vector2.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
            rb.MoveRotation(targetRotation);
            rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);
            float currentSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
            if (CanMove)
            {
                animator.SetFloat("Speed", currentSpeed);
            }
            //Debug.Log("Current Speed: " + currentSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            float currentSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
        
    }
}
