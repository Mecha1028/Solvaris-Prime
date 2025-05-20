using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_SpawnEnemies : MonoBehaviour
{
    public int KillCount = 0;
    public int KillsToGet = 20;
    private float SpawnTimer;


    private void Update()
    {
        if (KillCount < KillsToGet)
        {
            StartCoroutine(ShootCooldown());
        }
        else
        {
            Debug.Log("BOSS NOT ADDED");
        }
    }

    private void SpawnEnemy()
    {

    }



    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(SpawnTimer);
        SpawnEnemy();
    }
}
