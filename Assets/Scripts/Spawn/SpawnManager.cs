using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawn[] monsterSpawnArray;
    public Spawn[] bossSpawnArray;

    public List<GameObject> enemyList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        //第一波敌人生成
        foreach (var item in monsterSpawnArray)
        { 
            enemyList.Add(item.EnemySpawn());
        }
        while(enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);

        //第二波敌人生成
        foreach (var item in bossSpawnArray)
        {
            enemyList.Add(item.EnemySpawn());
        }
        yield return new WaitForSeconds(1f);
        foreach (var item in bossSpawnArray)
        {
            enemyList.Add(item.EnemySpawn());
        }
        while(enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第三波敌人生成
        foreach (var item in bossSpawnArray)
        {
            enemyList.Add(item.EnemySpawn());
        }
        yield return new WaitForSeconds(1f);
        foreach (var item in bossSpawnArray)
        {
            enemyList.Add(item.EnemySpawn());
        }
        yield return new WaitForSeconds(1f);
        foreach (var item in bossSpawnArray)
        {
            enemyList.Add(item.EnemySpawn());
        }
        while(enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
    }
}
