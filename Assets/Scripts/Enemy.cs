using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public int health = 3;
    public int armor = 0;
    public GameObject Dropped;
    public float attackRange = 5f;
    public int attackDamage = 1;
    public float attackTime = 2f;
    public LayerMask playerLayer;

    [Header("Movement Stuff")]
    public Transform target;
    public float speed = 4f;
    public float knockback = 5f;
    public float knockback_time = 1f;
    public float stoppingDistance = 10f;
    Vector3 target_pos;
    Rigidbody rb;

    bool attacking;
    bool takingDamage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerStats>().gameObject.transform;
    }
    void Update(){
        // make enemy move towards the player
        transform.LookAt(target);
        target_pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // stop at a certain distance
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= attackRange && !attacking && !takingDamage){
            StartCoroutine("startAttacking");
        }
        if (attacking && !takingDamage){
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }
        if (distance > stoppingDistance && !attacking && !takingDamage)
            rb.MovePosition(target_pos);
    }
    IEnumerator startAttacking(){
        attacking = true;
        Debug.Log("started attacking");
        // play animation
        yield return new WaitForSeconds(attackTime);
        Debug.Log("attack now!");
        TryAttacking();
    }

    IEnumerator TakeKnockback(){
        takingDamage = true;
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * knockback);
        yield return new WaitForSeconds(knockback_time);
        takingDamage = false;
    }

    void TryAttacking(){
        if (Physics.CheckSphere(transform.position, attackRange, playerLayer) && attacking){
            target.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
        attacking = false;
    }
    public void TakeDamage(int amountDmg){
    
        Debug.Log("We took damage");
        if (armor > 0){
            armor -= amountDmg;
            if (armor < 0){
                // the armor broke so we take some more damage to health
                health += armor;
            }
        }
        else {
            health -= amountDmg;
        }
        if (health <= 0){
            if (Random.Range(0, 6) == 0){
                // spawn a dropper
                Instantiate(Dropped, transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
        else{
            StartCoroutine("TakeKnockback");
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
