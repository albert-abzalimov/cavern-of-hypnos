using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawner")]
    public GameObject enemy;
    public float radius = 10f;

    [Header("Wave Timers")]
    public int start_amount_to_spawn = 10;
    public float time_starting_amount = 20f;
    public float time_increase = 10f;
    public int enemy_increase = 2;
    float current_time;

    int wave = 0;
    void Start()
    {
        current_time = time_starting_amount;
        SpawnEnemies(start_amount_to_spawn);
    }

    void Update(){
        current_time -= Time.deltaTime;

        if (current_time <= 0){
            // spawn next wave
            SpawnEnemies(start_amount_to_spawn + enemy_increase * wave);
            current_time = time_starting_amount + time_increase * (wave - 1);
        }
    }


    void SpawnEnemies(int amount_spawn){
        wave++;
        for(int i = 0; i < amount_spawn; i++){
            float randomX = Random.Range(-radius, radius);
            float randomZ = Random.Range(-radius, radius);

            Vector3 position = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            Instantiate(enemy, position, Quaternion.identity);
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
