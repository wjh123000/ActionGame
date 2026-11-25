using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletPostion;
    public GameObject bulletPrefab;
    public float attack = 100f;

    public void Shot()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletPostion.position, transform.root.rotation);
        bullet.GetComponent<Bullet>().attack = attack;
    }
}
