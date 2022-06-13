using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropped : MonoBehaviour
{
    public bool isHealth;
    public Sprite healthSprite;
    public Sprite armorSprite;
    private SpriteRenderer spriteRend;
    private GameObject cam;

    void Start(){
        cam = FindObjectOfType<Camera>().gameObject;
        spriteRend = GetComponent<SpriteRenderer>();
        if (Random.Range(0, 2) == 0){
            isHealth = true;
            spriteRend.sprite = healthSprite;
        }
        else{
            isHealth = false;
            spriteRend.sprite = armorSprite;
        }
    }

    void Update(){
        transform.LookAt(cam.transform);
    }
}
