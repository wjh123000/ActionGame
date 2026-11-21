using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InputActionAsset asset;
    private Rigidbody rb;
    public float speed = 2f;

    void Start()
    {
        asset.Enable();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (asset.FindAction("Jump").WasPressedThisFrame())
        {
            if(transform.position.y < 0.6f)
            {
                rb.AddForce(Vector3.up * 200);
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
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        
    }
}
