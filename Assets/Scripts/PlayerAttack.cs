using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerStats))]
public class PlayerAttack : MonoBehaviour
{
    PlayerStats stats;

    void Awake(){
        stats = gameObject.GetComponent<PlayerStats>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            // Attack
            // play some sound effects 
            // visuals
            Attack();
        }        
    }

    void Attack(){
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stats.attackRadius);
        foreach (var colliderHit in hitColliders){
            if (colliderHit.CompareTag("Enemy")){
                colliderHit.gameObject.GetComponent<Enemy>().TakeDamage(stats.attackDamage);
            }
        }
    }
}
