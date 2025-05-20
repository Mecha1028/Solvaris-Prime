using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_SpawnEnemies : MonoBehaviour
{
    public float SpawnTimer;

    public GameObject PB_Player;
    public GameObject[] Enemies;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int NumberOfEnemies = Enemies.Length;
        Vector2 EnemyPos = new Vector2(Random.Range(-16,16),Random.Range(-24,24));
        GameObject Enemy = Instantiate(Enemies[Random.Range(0,NumberOfEnemies)],EnemyPos, Quaternion.identity, transform);
        SC_Enemy script = Enemy.GetComponent<SC_Enemy>();
        script.PB_Player = PB_Player;
        StartCoroutine(ShootCooldown());
    }



    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(SpawnTimer);
        SpawnEnemy();
    }
}
