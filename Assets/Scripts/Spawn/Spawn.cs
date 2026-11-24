using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;

    public GameObject EnemySpawn()
    {
        return GameObject.Instantiate(prefab, transform.position, transform.rotation) as GameObject;
    }
}
