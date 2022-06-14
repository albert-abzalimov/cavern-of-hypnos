using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCont2 : MonoBehaviour {

    public GameObject player;        //Public variable to store a reference to the player game object

    bool look_back = false;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Q)){
            look_back = !look_back;
        }

        if (look_back){
            Quaternion back_angle = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = back_angle;
        }
        else{
            Quaternion forward_angle = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z); 
            transform.rotation = forward_angle;
        }
    }
}
