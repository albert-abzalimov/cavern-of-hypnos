using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 5;
    public int armor = 0;

    [Header("Attack")]
    public float attackSpeed = 1f;
    public int attackDamage = 1;
    public float attackRadius = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int amountDmg){
        Debug.LogWarning("TOOK DAMAGE");
        health -= amountDmg;
        if (health <= 0){
            // You died
            OnDeath();
        }
    }

    void OnDeath(){
        Debug.Log("U died haha");
        gameObject.SetActive(false);
    }
}
