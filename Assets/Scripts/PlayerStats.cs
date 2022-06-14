using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 5;
    public int armor = 0;
    public TextMeshProUGUI health_ui;
    public TextMeshProUGUI armor_ui;

    [Header("Attack")]
    public float attackSpeed = 1f;
    public int attackDamage = 1;
    public float attackRadius = 2f;

    void Start(){
        health_ui.text = "Health: " + health;
        armor_ui.text = "Armor: " + armor;
    }
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
        health_ui.text = "Health: " + health;
        armor_ui.text = "Armor: " + armor;
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
            health_ui.text = "Health: " + health;
            armor_ui.text = "Armor: " + armor;
            Destroy(other.gameObject);
        } 
        else if (other.CompareTag("Void")){
            OnDeath();
        }
    }
}
