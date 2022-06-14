using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterBuilding : MonoBehaviour
{
    public string loadingScene;


    private void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(loadingScene);
        }
    }
}

