using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 2f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    void Update()
    {
        Vector3 targetPos = player.position + new Vector3(0, 2.42f, -2.42f);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
}
