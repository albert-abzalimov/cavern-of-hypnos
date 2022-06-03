using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 3;
    public int armor = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amountDmg){
        Debug.Log("We took damage");
        if (armor > 0){
            armor -= amountDmg;
            if (armor < 0){
                // the armor broke so we take some more damage to health
                health -= armor;
            }
        }
        else {
            health -= amountDmg;
        }
        if (health <= 0){
            Debug.Log("enemy died");
            gameObject.SetActive(false);
        }
    }
}
