using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 5;
    public int armor = 0;

    [Header("Attack")]
    public float attackSpeed = 1f;
    public int attackDamage = 1;
    public float attackRadius = 2f;

    public void TakeDamage(int amountDmg){
        Debug.LogWarning("TOOK DAMAGE");
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
            // You died
            OnDeath();
        }
    }

    void OnDeath(){
        Debug.Log("U died haha");
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Dropped")){
            if (other.GetComponent<Dropped>().isHealth){
                // get more health
                health++;
            }
            else {
                // get more armor 
                armor++;
            }
            Destroy(other.gameObject);
        } 
        else if (other.CompareTag("Void")){
            OnDeath();
        }
    }
}
