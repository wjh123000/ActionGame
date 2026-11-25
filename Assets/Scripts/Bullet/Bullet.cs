using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float attack = 20f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.soulBoss || other.tag == Tags.soulMonster)
        {
            other.GetComponent<ATKAndDamage>().TakeDamage(attack);
            Destroy(gameObject);
        }
    }
}
