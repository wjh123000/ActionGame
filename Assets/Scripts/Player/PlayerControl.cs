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
    void FixedUpdate()
    {
        Vector2 dir = asset.FindAction("Move").ReadValue<Vector2>();
        transform.LookAt(new Vector3(dir.x, 0, dir.y) + transform.position);
        if (dir != Vector2.zero)
        {
            rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (asset.FindAction("Jump").IsPressed())
        {
            rb.AddForce(Vector3.up * 20);
        }
    }
}
