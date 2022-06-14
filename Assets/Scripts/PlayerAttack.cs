using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerStats))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    bool attacking = false;
    float attack_cooldown;
    public Animator Anim;

    void Awake(){
        stats = gameObject.GetComponent<PlayerStats>();
        attack_cooldown = stats.attackSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("attacking", attacking);
        if (attacking){
            attack_cooldown -= Time.deltaTime;
        }
        else if (Input.GetButtonDown("Fire1")){
            // Attack
            // play some sound effects 
            // visuals
            Attack();
        }        
        if (attack_cooldown <= 0){
            attacking = false;
            attack_cooldown = stats.attackSpeed;
        }
    }
    

    void Attack(){
        attacking = true;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stats.attackRadius);
        foreach (var colliderHit in hitColliders){
            if (colliderHit.CompareTag("Enemy")){
                colliderHit.gameObject.GetComponent<Enemy>().TakeDamage(stats.attackDamage);
            }
        }
    }
    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, stats.attackRadius);
    }
    
}
